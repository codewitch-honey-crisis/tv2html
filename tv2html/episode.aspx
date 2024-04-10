<!DOCTYPE html>
<%
	dynamic series = Arguments["series"];
	dynamic season = Arguments["season"];
	dynamic episode = Arguments["episode"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];
	var eps_id = (string)Arguments["episode_id"];
	var eps = (string)Arguments["episode_fullname"];
%>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../web/w3.css">
    <title><%=episode.name%> - <%=series.name%></title>
    <style>
        .w3-bar-block .w3-bar-item {
            padding: 20px
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        h3 {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size: larger;
        }

        .stars {
            color: orange;
        }
        video {
            object-fit: contain;
            max-width:1200px;
            margin: auto;
        }
    </style>
</head>
<body>
    <!-- Sidebar (hidden by default) -->
    <nav class="w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left" style="display: none; z-index: 2; width: 40%; min-width: 300px" id="mySidebar">
        <a href="../index.html" onclick="w3_close()"
            class="w3-bar-item w3-button"><%=series.name %></a>
        <a href="index.html" onclick="w3_close()" class="w3-bar-item w3-button">All Episodes</a>
        <%
 foreach(var episode_obj in season.episodes) {
     dynamic e = episode_obj;
     var e_file = string.Format("S{0:00}E{1:00} {2}.html",e.season_number,e.episode_number,e.name);
        %>
        <a href="<%=e_file%>" onclick="w3_close()" class="w3-bar-item w3-button"><%=e.name%></a>
        <%
 }
        %>
    </nav>
    <div class="w3-top">
        <div class="w3-white w3-xlarge" style="max-width: 1200px; margin: auto">
            <div class="w3-button w3-padding-16 w3-left" onclick="w3_open()">☰</div>
            <% if((double)episode.vote_average!=double.NaN && (double)episode.vote_average>0.0) {%>
            <div class="w3-right w3-padding-16">
                <span class="stars"><% 
			double avg = ((double)episode.vote_average)/2.0;
			for(int rsi = 0;rsi<5;++rsi) {
				if(Math.Round(avg)>rsi) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                %></span><span><%=" "+(Math.Round(avg*10)/10.0).ToString() %></span>
            </div>
            <% } %>
            <div class="w3-center w3-padding-16"><%=episode.name%> - <%=series.name%></div>
        </div>
    </div>
    <div class="w3-main w3-content w3-padding" style="max-width: 1200px; margin-top: 100px">
<%
    string? vid_ext = null;
    string? media_type = null;
    var vid_file = System.IO.Path.Combine(series_dir.FullName,Tmdb.GetSafePath((string)season.name));
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
    %>
        <video muted autoplay controls>
            <source src="<%=vid_url%>" type="<%=media_type%>"/>
        </video>
<%} else {
        var still_ext = System.IO.Path.GetExtension((string)episode.still_path);
        var still_url = "../web/"+System.Web.HttpUtility.UrlEncode(eps+still_ext).Replace("+","%20");
    %>
        <div>
        <img alt="<%=eps+" (unavailable)"%>" style="width:100%;" src="<%=still_url%>" /> 
        </div>
        <div><center><h3 style="color: red;">Not available</h3></center></div>
        
<%}%>
         <% if(!string.IsNullOrEmpty(episode.overview as string)) { %>
 <div class="w3-white w3-large" style="max-width: 1200px; margin: auto">
     <p><%=episode.overview %></p>
 </div>
 <%} %>
    </div>
    <script>
    // Script to open and close sidebar
    function w3_open() {
        document.getElementById("mySidebar").style.display = "block";
    }

    function w3_close() {
        document.getElementById("mySidebar").style.display = "none";
    }
    </script>
</body>
</html>
