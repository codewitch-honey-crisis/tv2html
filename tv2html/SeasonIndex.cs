using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
#line hidden
public partial class SeasonIndex {
    public static void Run(TextWriter Response, IDictionary<string, object> Arguments) {
        #line 3 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("<!DOCTYPE html>\r\n<html>\r\n");
        #line 3 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"

	dynamic series = Arguments["series"];
	dynamic season = Arguments["season"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];


        #line 10 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <link rel=\"stylesheet\" href=\"../web/w3.css\">\r\n    <title>");
        #line 16 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write( season.name );
        #line 16 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(" - ");
        #line 16 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(series.name);
        #line 16 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</title>\r\n    <style>\r\n        .w3-bar-block .w3-bar-item {\r\n            padding: 20px\r\n        }\r\n\r\n\r\n        body {\r\n            font-family: \'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif;\r\n        }\r\n\r\n        h3 {\r\n            font-family: \'Lucida Sans\', \'Lucida Sans Regular\', \'Lucida Grande\', \'Lucida Sans Unicode\', Geneva, Verdana, sans-serif;\r\n            font-size: larger;\r\n        }\r\n\r\n        .stars {\r\n            color: orange;\r\n        }\r\n\r\n        .eps_link {\r\n            text-decoration: none;\r\n            color: black;\r\n        }\r\n\r\n            .eps_link:hover {\r\n                color: black;\r\n            }\r\n    </style>\r\n</head>\r\n<body>\r\n    <!-- Sidebar (hidden by default) -->\r\n    <nav class=\"w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left\" style=\"display: none; z-index: 2; width: 40%; min-width: 300px\" id=\"mySidebar\">\r\n        <a href=\"../index.html\" onclick=\"w3_close()\"\r\n            class=\"w3-bar-item w3-button\">");
        #line 50 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(series.name );
        #line 50 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</a>\r\n        <a href=\"#episodes\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">All Episodes</a>\r\n        ");
        #line 52 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"

    foreach(var episode_obj in season.episodes) {
        dynamic episode = episode_obj;
        var eps_href = Tmdb.GetSafeFilename(string.Format("S{0:00}E{1:00} {2}.html",episode.season_number,episode.episode_number,episode.name));
        
        #line 56 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n        <a href=\"");
        #line 57 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(eps_href);
        #line 57 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">");
        #line 57 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(episode.name);
        #line 57 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</a>\r\n        ");
        #line 58 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"

    }
        
        #line 60 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n    </nav>\r\n    <div class=\"w3-top\">\r\n        <div class=\"w3-white w3-xlarge\" style=\"max-width: 1200px; margin: auto\">\r\n            <div class=\"w3-button w3-padding-16 w3-left\" onclick=\"w3_open()\">☰</div>\r\n            ");
        #line 65 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 if((double)season.vote_average!=double.NaN && (double)season.vote_average>0.0) {
        #line 65 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n            <div class=\"w3-right w3-padding-16\">\r\n                <span class=\"stars\">");
        #line 67 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 
			double avg = ((double)season.vote_average)/2.0;
			for(int rsi = 0;rsi<5;++rsi) {
				if(Math.Round(avg)>rsi) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                
        #line 76 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</span><span>");
        #line 76 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(" "+avg.ToString() );
        #line 76 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</span>\r\n            </div>\r\n            ");
        #line 78 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 } 
        #line 78 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n            <div class=\"w3-center w3-padding-16\">");
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(season.name);
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(" - ");
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(series.name);
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</div>\r\n            <div class=\"w3-center\">\r\n                <span>");
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(season.episodes.Count );
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(" episode");
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(season.episodes.Count!=1?"s":"");
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</span>\r\n            </div>\r\n            ");
        #line 83 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 if(!string.IsNullOrEmpty(season.overview as string)) { 
        #line 83 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n            <div class=\"w3-white w3-large\" style=\"max-width: 1200px; margin: auto\">\r\n                <p>");
        #line 85 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(season.overview );
        #line 85 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</p>\r\n            </div>\r\n            ");
        #line 87 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
} 
        #line 87 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n        </div>\r\n    </div>\r\n    <div class=\"w3-main w3-content w3-padding\" style=\"max-width: 1200px; margin-top: 100px\">\r\n        ");
        #line 91 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"

        var eidx = 0;
        while(eidx<season.episodes.Count) {
            dynamic episode = season.episodes[eidx];
            var eps_id = string.Format("S{0:00}E{1:00}",episode.season_number,episode.episode_number);
            var eps = eps_id+" "+(string)episode.name;
            if(0==(eidx%4)) {
        
        #line 98 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("<div class=\"w3-row-padding w3-padding-16 w3-center\" ");
        #line 98 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(eidx==0?"id=\"episodes\"":"");
        #line 98 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(">\r\n            ");
        #line 99 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 
            }
            
        #line 101 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n            <div class=\"w3-quarter\" id=\"");
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(eps_id);
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\">\r\n                <a class=\"eps_link\" href=\"");
        #line 103 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(System.Web.HttpUtility.UrlEncode(Tmdb.GetSafeFilename( eps+".html")).Replace("+","%20"));
        #line 103 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\">\r\n                    ");
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 if(!string.IsNullOrEmpty(episode.still_path as string)) {
	var ext = System.IO.Path.GetExtension((string)episode.still_path);
	var ppath = System.IO.Path.Combine(series_dir.FullName,"web");
    var pfn=Tmdb.GetSafeFilename((string)eps+ext);
	ppath = System.IO.Path.Combine(ppath,pfn);
	Tmdb.Download(image_base+"original"+(string)episode.still_path,ppath);
                    
        #line 110 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                    <center>\r\n                        <div>\r\n                            <img src=\"../web/");
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(System.Web.HttpUtility.UrlEncode(pfn).Replace("+","%20"));
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\" alt=\"");
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(eps);
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\" style=\"width: 100%\" />\r\n                        </div>\r\n                    </center>\r\n\r\n                    ");
        #line 117 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
} 
        #line 117 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                    <h3>");
        #line 118 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(episode.name );
        #line 118 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</h3>\r\n                    ");
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 if((double)episode.vote_average!=double.NaN && (double)episode.vote_average>0.0) {
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                    <div>\r\n                        <span class=\"stars\">");
        #line 121 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 
			double avg = ((double)episode.vote_average)/2.0;
			for(int ri = 0;ri<5;++ri) {
				if(Math.Round(avg)>ri) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                        
        #line 130 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</span><span>");
        #line 130 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(" "+(Math.Round(avg*10)/10.0).ToString() );
        #line 130 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</span>\r\n                    </div>\r\n                    ");
        #line 132 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 } 
        #line 132 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                    ");
        #line 133 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
if(!string.IsNullOrEmpty(episode.overview as string)) { 
        #line 133 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                    <p>");
        #line 134 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write(episode.overview );
        #line 134 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("</p>\r\n                    ");
        #line 135 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
} 
        #line 135 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n                </a>\r\n            </div>\r\n            ");
        #line 138 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"

            if(3==(eidx%4)) {
            
        #line 140 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n        </div>\r\n        ");
        #line 142 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
 
            }
            ++eidx;
        }
        
        #line 146 "C:\Users\gazto\source\repos\tv2html\tv2html\season.index.aspx"
        Response.Write("\r\n    </div>\r\n    <script>\r\n        // Script to open and close sidebar\r\n        function w3_open() {\r\n            document.getElementById(\"mySidebar\").style.display = \"block\";\r\n        }\r\n\r\n        function w3_close() {\r\n            document.getElementById(\"mySidebar\").style.display = \"none\";\r\n        }\r\n    </script>\r\n\r\n</body>\r\n</html>\r\n");
        Response.Flush();
    }
}
