using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
#line hidden
public partial class SeriesIndex {
    public static void Run(TextWriter Response, IDictionary<string, object> Arguments) {
        #line 3 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("<!DOCTYPE html>\r\n<html>\r\n");
        #line 3 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"

	dynamic series = Arguments["series"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];


        #line 9 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <link rel=\"stylesheet\" href=\"web/w3.css\">\r\n    <title>");
        #line 15 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.name);
        #line 15 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</title>\r\n    <style>\r\n        .w3-bar-block .w3-bar-item {\r\n            padding: 20px\r\n        }\r\n\r\n\r\n        body {\r\n            font-family: \'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif;\r\n        }\r\n\r\n        h3 {\r\n            font-family: \'Lucida Sans\', \'Lucida Sans Regular\', \'Lucida Grande\', \'Lucida Sans Unicode\', Geneva, Verdana, sans-serif;\r\n            font-size: larger;\r\n        }\r\n\r\n        .stars {\r\n            color: orange;\r\n        }\r\n        \r\n\r\n    </style>\r\n\r\n</head>\r\n<body>\r\n\r\n    <!-- Sidebar (hidden by default) -->\r\n    <nav class=\"w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left\" style=\"display: none; z-index: 2; width: 40%; min-width: 300px\" id=\"mySidebar\">\r\n        <!--<a href=\"index.html\" onclick=\"w3_close()\"\r\n            class=\"w3-bar-item w3-button\">");
        #line 44 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.name );
        #line 44 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</a>-->\r\n        <a href=\"#seasons\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">All Seasons</a>\r\n        ");
        #line 46 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"

    foreach(var season_obj in series.seasons) {
        dynamic season = season_obj;
        //season = Tmdb.GetObject("https://api.themoviedb.org/3/tv/2919/season/"+string.Concat(season.season_number,"?language=",Arguments["lang"]));
        var s_id = string.Format("S{0:00}",season.season_number);
        var s_href=System.Web.HttpUtility.UrlEncode((string)season.name).Replace("+","%20").Replace(" ","%20")+"/index.html";
        
        #line 52 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n        <a href=\"");
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(s_href);
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">");
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(season.name);
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</a>\r\n        ");
        #line 54 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"

    }
        
        #line 56 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n    </nav>\r\n    <div class=\"w3-top\">\r\n        <div class=\"w3-white w3-xlarge\" style=\"max-width: 1200px; margin: auto\">\r\n            <div class=\"w3-button w3-padding-16 w3-left\" onclick=\"w3_open()\">☰</div>\r\n");
        #line 61 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 if((double)series.vote_average!=double.NaN && (double)series.vote_average>0.0) {
        #line 61 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n\t\t<div class=\"w3-right w3-padding-16\"><span class=\"stars\">");
        #line 62 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 
			double avg = ((double)series.vote_average)/2.0;
			for(int rsi = 0;rsi<5;++rsi) {
				if(Math.Round(avg)>rsi) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
			
        #line 71 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</span><span>");
        #line 71 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(" "+avg.ToString() );
        #line 71 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</span>\r\n\t\t</div>\r\n");
        #line 73 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 } 
        #line 73 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\t\t\r\n        <div class=\"w3-center w3-padding-16\">");
        #line 74 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.name);
        #line 74 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</div>\r\n        </div>\r\n        <div class=\"w3-center\">\r\n            <span>");
        #line 77 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.seasons.Count );
        #line 77 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(" season");
        #line 77 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.seasons.Count!=1?"s":"");
        #line 77 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</span>\r\n        </div>\r\n");
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 if(!string.IsNullOrEmpty(series.overview as string)) { 
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n        <div class=\"w3-white w3-large\" style=\"max-width: 1200px; margin: auto\">\r\n            <p>");
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(series.overview );
        #line 81 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</p>\r\n        </div>\r\n");
        #line 83 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
} 
        #line 83 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n    </div>\r\n    <div class=\"w3-main w3-content w3-padding\" style=\"max-width: 1200px; margin-top: 100px\">\r\n        ");
        #line 86 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"

        var sidx = 0;
        while(sidx<series.seasons.Count) {
            dynamic season = series.seasons[sidx];
            season = Tmdb.GetObject("https://api.themoviedb.org/3/tv/2919/season/"+string.Concat(season.season_number,"?language=",Arguments["lang"]));
            var s_id = string.Format("S{0:00}",season.season_number);
            if(0==(sidx%4)) {
                
        #line 93 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("<div class=\"w3-row-padding w3-padding-16 w3-center\" ");
        #line 93 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(sidx==0?"id=\"seasons\"":"");
        #line 93 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(">");
        #line 93 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 
            }
            
        #line 95 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n                <a href=\"");
        #line 96 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(season.name);
        #line 96 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("/index.html\"><div class=\"w3-quarter\" id=\"");
        #line 96 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(s_id);
        #line 96 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\">\r\n");
        #line 97 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 if(!string.IsNullOrEmpty(season.poster_path as string)) {
	var ext = System.IO.Path.GetExtension((string)season.poster_path);
	var ppath = System.IO.Path.Combine(series_dir.FullName,"web");
	ppath = System.IO.Path.Combine(ppath,Tmdb.GetSafePath((string)season.name)+".poster"+ext);
	Tmdb.Download(image_base+"original"+(string)season.poster_path,ppath);
	
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n            <center><div>\r\n\t\t\t\t<img src=\"web/");
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(System.Web.HttpUtility.UrlEncode(Tmdb.GetSafePath((string)season.name)).Replace("+","%20")+".poster"+ext);
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\" alt=\"");
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(season.name);
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\" style=\"width: 100%\" />\r\n    </div></center>\r\n        \r\n");
        #line 107 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
} 
        #line 107 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n                  <h3>");
        #line 108 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(season.name );
        #line 108 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</h3>\r\n");
        #line 109 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 if((double)season.vote_average!=double.NaN && (double)season.vote_average>0.0) {
        #line 109 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n\t\t<div><span class=\"stars\">");
        #line 110 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 
			double avg = ((double)season.vote_average)/2.0;
			for(int ri = 0;ri<5;++ri) {
				if(Math.Round(avg)>ri) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
			
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</span><span>");
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(" "+(Math.Round(avg*10)/10.0).ToString() );
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</span>\r\n\t\t</div>\r\n");
        #line 121 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 } 
        #line 121 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\t\t\r\n");
        #line 122 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
if(!string.IsNullOrEmpty(season.overview as string)) { 
        #line 122 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n                    <center><p style=\"margin-bottom:20px\">");
        #line 123 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write(season.overview );
        #line 123 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</p></center>\r\n");
        #line 124 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
} 
        #line 124 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n                </div></a>\r\n            ");
        #line 126 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"

            if(3==(sidx%4)) {
                
        #line 128 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("</div>");
        #line 128 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
 
            }
            ++sidx;
        }
        
        #line 132 "C:\Users\gazto\source\repos\tv2html\tv2html\series.index.aspx"
        Response.Write("\r\n    </div>\r\n    <script>\r\n        // Script to open and close sidebar\r\n        function w3_open() {\r\n            document.getElementById(\"mySidebar\").style.display = \"block\";\r\n        }\r\n\r\n        function w3_close() {\r\n            document.getElementById(\"mySidebar\").style.display = \"none\";\r\n        }\r\n    </script>\r\n\r\n</body>\r\n</html>\r\n");
        Response.Flush();
    }
}
