using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
#line hidden
public partial class Episode {
    public static void Run(TextWriter Response, IDictionary<string, object> Arguments) {
        #line 2 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("﻿<!DOCTYPE html>\r\n");
        #line 2 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"

	dynamic series = Arguments["series"];
	dynamic season = Arguments["season"];
	dynamic episode = Arguments["episode"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];
	var eps_id = (string)Arguments["episode_id"];
	var eps = (string)Arguments["episode_fullname"];

        #line 11 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n<html>\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <link rel=\"stylesheet\" href=\"../web/w3.css\">\r\n    <title>");
        #line 17 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(episode.name);
        #line 17 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(" - ");
        #line 17 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(series.name);
        #line 17 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</title>\r\n    <style>\r\n        .w3-bar-block .w3-bar-item {\r\n            padding: 20px\r\n        }\r\n\r\n        body {\r\n            font-family: \'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif;\r\n        }\r\n\r\n        h3 {\r\n            font-family: \'Lucida Sans\', \'Lucida Sans Regular\', \'Lucida Grande\', \'Lucida Sans Unicode\', Geneva, Verdana, sans-serif;\r\n            font-size: larger;\r\n        }\r\n\r\n        .stars {\r\n            color: orange;\r\n        }\r\n        video {\r\n            object-fit: contain;\r\n            max-width:1200px;\r\n            margin: auto;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <!-- Sidebar (hidden by default) -->\r\n    <nav class=\"w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left\" style=\"display: none; z-index: 2; width: 40%; min-width: 300px\" id=\"mySidebar\">\r\n        <a href=\"../index.html\" onclick=\"w3_close()\"\r\n            class=\"w3-bar-item w3-button\">");
        #line 46 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(series.name );
        #line 46 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</a>\r\n        <a href=\"index.html\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">All Episodes</a>\r\n        ");
        #line 48 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"

 foreach(var episode_obj in season.episodes) {
     dynamic e = episode_obj;
     var e_file = Tmdb.GetSafeFilename(string.Format("S{0:00}E{1:00} {2}.html",e.season_number,e.episode_number,e.name));
        
        #line 52 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n        <a href=\"");
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(System.Web.HttpUtility.UrlEncode(e_file).Replace("+","%20"));
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\" onclick=\"w3_close()\" class=\"w3-bar-item w3-button\">");
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(e.name);
        #line 53 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</a>\r\n        ");
        #line 54 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"

 }
        
        #line 56 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n    </nav>\r\n    <div class=\"w3-top\">\r\n        <div class=\"w3-white w3-xlarge\" style=\"max-width: 1200px; margin: auto\">\r\n            <div class=\"w3-button w3-padding-16 w3-left\" onclick=\"w3_open()\">☰</div>\r\n            ");
        #line 61 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
 if((double)episode.vote_average!=double.NaN && (double)episode.vote_average>0.0) {
        #line 61 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n            <div class=\"w3-right w3-padding-16\">\r\n                <span class=\"stars\">");
        #line 63 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
 
			double avg = ((double)episode.vote_average)/2.0;
			for(int rsi = 0;rsi<5;++rsi) {
				if(Math.Round(avg)>rsi) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                
        #line 72 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</span><span>");
        #line 72 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(" "+(Math.Round(avg*10)/10.0).ToString() );
        #line 72 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</span>\r\n            </div>\r\n            ");
        #line 74 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
 } 
        #line 74 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n            <div class=\"w3-center w3-padding-16\">");
        #line 75 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(episode.name);
        #line 75 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(" - ");
        #line 75 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(series.name);
        #line 75 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</div>\r\n        </div>\r\n    </div>\r\n    <div class=\"w3-main w3-content w3-padding\" style=\"max-width: 1200px; margin-top: 100px\">\r\n");
        #line 79 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"

    string? vid_ext = null;
    string? media_type = null;
    var vid_file = System.IO.Path.Combine(series_dir.FullName,Tmdb.GetSafeFilename((string)season.name));
    vid_file = System.IO.Path.Combine(vid_file,eps);
    if(System.IO.File.Exists(vid_file+".mp4")) {
        vid_ext = ".mp4";
        media_type = "video/mp4";
    } else if(System.IO.File.Exists(vid_file+".webm")) {
        vid_ext = ".webm";
        media_type = "video/webm";
    } else if(System.IO.File.Exists(vid_file+".ogg")) {
        vid_ext = ".ogg";
        media_type = "video/ogg";
    } else if(System.IO.File.Exists(vid_file+".mpeg")) {
        vid_ext = ".mpeg";
        media_type = "video/mpeg";
    }

    if(vid_ext!=null) {
        var vid_url = System.Web.HttpUtility.UrlEncode(eps+vid_ext).Replace("+","%20");
    
        #line 100 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n        <video muted autoplay controls>\r\n            <source src=\"");
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(vid_url);
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\" type=\"");
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(media_type);
        #line 102 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\"/>\r\n        </video>\r\n");
        #line 104 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
} else {

        var still_ext = System.IO.Path.GetExtension((string)episode.still_path);
        var still_url = "../web/"+System.Web.HttpUtility.UrlEncode(Tmdb.GetSafeFilename(eps+still_ext)).Replace("+","%20");
    
        #line 108 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n        ");
        #line 109 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
if(!string.IsNullOrEmpty((string)episode.still_path)){ 
        #line 109 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n        <div>\r\n        <img alt=\"");
        #line 111 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(eps+" (unavailable)");
        #line 111 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\" style=\"width:100%;\" src=\"");
        #line 111 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(still_url);
        #line 111 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\" /> \r\n        </div>\r\n        ");
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
} 
        #line 113 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n        <div><center><h3 style=\"color: red;\">Not available</h3></center></div>\r\n        \r\n");
        #line 116 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
}
        #line 116 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n         ");
        #line 117 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
 if(!string.IsNullOrEmpty(episode.overview as string)) { 
        #line 117 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n <div class=\"w3-white w3-large\" style=\"max-width: 1200px; margin: auto\">\r\n     <p>");
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write(episode.overview );
        #line 119 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("</p>\r\n </div>\r\n ");
        #line 121 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
} 
        #line 121 "C:\Users\gazto\source\repos\tv2html\tv2html\episode.aspx"
        Response.Write("\r\n    </div>\r\n    <script>\r\n    // Script to open and close sidebar\r\n    function w3_open() {\r\n        document.getElementById(\"mySidebar\").style.display = \"block\";\r\n    }\r\n\r\n    function w3_close() {\r\n        document.getElementById(\"mySidebar\").style.display = \"none\";\r\n    }\r\n    </script>\r\n</body>\r\n</html>");
        Response.Flush();
    }
}
