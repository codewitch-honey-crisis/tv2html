using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

static partial class Program
{
	static int ExitCode = 0;
	[CmdArg(Ordinal = 0, Required = true, ItemName = "series", Description = "The TV series to search for")]
	static string? Series = null;
	[CmdArg(Ordinal = 1, Required = true, ItemName = "auth", Description = "The TMDb auth token to use")]
	static string? AuthToken = null;

	[CmdArg("output", ItemName = "path", Description = "The path to the directory to output at")]
	static DirectoryInfo? Output = null;
	[CmdArg("lang", ItemName = "lang", Description = "The language code to search. Default en-US")]
	static string Language = "en-US";
	static int SeriesId = -1;
	static void Run()
	{

		if (Output == null)
		{
			Output = new DirectoryInfo(".");
		}
		Tmdb.AuthToken = AuthToken!;

		dynamic config = Tmdb.GetObject("https://api.themoviedb.org/3/configuration");
		if (Series!.StartsWith('#'))
		{
			if (!int.TryParse(Series.Substring(1), out SeriesId))
			{
				SeriesId = -1;
			}
		}
		if (0 > SeriesId)
		{
			int total_pages = -1;
			for (int page = 1; (total_pages == -1 || page <= total_pages); ++page)
			{
				dynamic results = Tmdb.GetObject(string.Format("https://api.themoviedb.org/3/search/tv?include_adult=false&language={0}&page={1},&query={2}", Language, page, HttpUtility.HtmlEncode(Series)));
				total_pages = (int)results.total_pages;
				int total_results = (int)results.total_results;
				if (total_results == 1)
				{
					SeriesId = (int)results.results[0].id;
					break;
				}
				else if (total_results == 0)
				{
					Console.WriteLine("<No Results>");
					break;
				}
				else
				{
					dynamic result;

					foreach (var r in results.results)
					{
						result = r;
						Console.WriteLine("\t#{0}\t{1}{2}", result.id, result.name, !string.IsNullOrEmpty((string)result.first_air_date) ? (" - First aired " + (string)result.first_air_date) : "");
					}
				}
			}
		}
		if (0 > SeriesId)
		{
			ExitCode = 2;
			return;
		}
		var uri = string.Format("https://api.themoviedb.org/3/tv/{0}?language={1}", SeriesId, Language);
		dynamic series = Tmdb.GetObject(uri);
		var args = new Dictionary<string, object>();
		args["config"] = config;
		args["series"] = series;
		args["lang"] = Language;
		var seriesDir = Output.CreateSubdirectory(Tmdb.GetSafePath((string)series.name));
		args["series_dir"] = seriesDir;
		using (var writer = new StreamWriter(Path.Combine(seriesDir.FullName, "index.html"), false, Encoding.UTF8))
		{
			SeriesIndex.Run(writer, args);
		}
		using (var outstm = File.OpenWrite(Path.Combine(Path.Combine(seriesDir.FullName, "web"), "w3.css")))
		{
			using (var instm = Assembly.GetExecutingAssembly().GetManifestResourceStream("tv2html.w3.css"))
			{
				instm!.CopyTo(outstm);
			}
		}
		using (var outstm = File.OpenWrite(Path.Combine(Path.Combine(seriesDir.FullName, "web"), "play.svg")))
		{
			using (var instm = Assembly.GetExecutingAssembly().GetManifestResourceStream("tv2html.play.svg"))
			{
				instm!.CopyTo(outstm);
			}
		}
		for (int i = 0; i < series.seasons.Count; i++)
		{
			dynamic season = series.seasons[i];
			var seasonDir = seriesDir.CreateSubdirectory(Tmdb.GetSafePath((string)season.name));
			season = Tmdb.GetObject("https://api.themoviedb.org/3/tv/2919/season/" + string.Concat(season.season_number, "?language=", Language));
			args["season"] = season;
			using (var writer = new StreamWriter(Path.Combine(seasonDir.FullName, "index.html"), false, Encoding.UTF8))
			{
				SeasonIndex.Run(writer, args);
			}
			for (int j = 0; j < season.episodes.Count; j++)
			{
				dynamic episode = season.episodes[j];
				args["episode"] = episode;
				var eps_id = string.Format("S{0:00}E{1:00}", episode.season_number, episode.episode_number);
				var eps = string.Concat(eps_id," ",(string)episode.name);
				args["episode_id"] = eps_id;
				args["episode_fullname"] = eps;
				using(var writer = new StreamWriter(Path.Combine(seasonDir.FullName,eps+".html")))
				{
					Episode.Run(writer, args);
				}
				
			}
		}
	}
}