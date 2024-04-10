<!DOCTYPE html>
<html>
<%
	dynamic series = Arguments["series"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];

%>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="web/w3.css">
    <title><%=series.name%></title>
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
    </style>

</head>
<body>

    <!-- Sidebar (hidden by default) -->
    <nav class="w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left" style="display: none; z-index: 2; width: 40%; min-width: 300px" id="mySidebar">
        <!--<a href="index.html" onclick="w3_close()"
            class="w3-bar-item w3-button"><%=series.name %></a>-->
        <a href="#seasons" onclick="w3_close()" class="w3-bar-item w3-button">All Seasons</a>
        <%
    foreach(var season_obj in series.seasons) {
        dynamic season = season_obj;
        //season = Tmdb.GetObject("https://api.themoviedb.org/3/tv/"+((string)series.id)+"/season/"+string.Concat(season.season_number,"?language=",Arguments["lang"]));
        var s_id = string.Format("S{0:00}",season.season_number);
        var s_href=System.Web.HttpUtility.UrlEncode(Tmdb.GetSafeFilename((string)season.name)).Replace("+","%20").Replace(" ","%20")+"/index.html";
        %>
        <a href="<%=s_href%>" onclick="w3_close()" class="w3-bar-item w3-button"><%=season.name%></a>
        <%
    }
        %>
    </nav>
    <div class="w3-top">
        <div class="w3-white w3-xlarge" style="max-width: 1200px; margin: auto">
            <div class="w3-button w3-padding-16 w3-left" onclick="w3_open()">☰</div>
            <% if((double)series.vote_average!=double.NaN && (double)series.vote_average>0.0) {%>
            <div class="w3-right w3-padding-16">
                <span class="stars"><% 
			double avg = ((double)series.vote_average)/2.0;
			for(int rsi = 0;rsi<5;++rsi) {
				if(Math.Round(avg)>rsi) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                %></span><span><%=" "+avg.ToString() %></span>
            </div>
            <% } %>
            <div class="w3-center w3-padding-16">
                <%=series.name%>
            </div>
            <div class="w3-center">
                <span><%=series.seasons.Count %> season<%=series.seasons.Count!=1?"s":""%></span>
            </div>
            <% if(!string.IsNullOrEmpty(series.overview as string)) { %>
            <div class="w3-white w3-large" style="max-width: 1200px; margin: auto">
                <p><%=series.overview %></p>
            </div>
            <%} %>
        </div>

    </div>
    <div class="w3-main w3-content w3-padding" style="max-width: 1200px; margin-top: 150px">
        <%
        var sidx = 0;
        while(sidx<series.seasons.Count) {
            dynamic season = series.seasons[sidx];
            season = Tmdb.GetObject(string.Concat("https://api.themoviedb.org/3/tv/",series.id,"/season/",season.season_number,"?language=",Arguments["lang"]));
            var s_id = string.Format("S{0:00}",season.season_number);
            if(0==(sidx%4)) {
        %><div class="w3-row-padding w3-padding-16 w3-center" <%=sidx==0?"id=\"seasons\"":""%>>
            <% 
            }
            %>
            <a href="<%=Tmdb.GetSafeFilename((string)season.name)%>/index.html">
                <div class="w3-quarter" id="<%=s_id%>">
                    <% if(!string.IsNullOrEmpty(season.poster_path as string)) {
	var ext = System.IO.Path.GetExtension((string)season.poster_path);
	var ppath = System.IO.Path.Combine(series_dir.FullName,"web");
	ppath = System.IO.Path.Combine(ppath,Tmdb.GetSafeFilename((string)season.name)+".poster"+ext);
	Tmdb.Download(image_base+"original"+(string)season.poster_path,ppath);
                    %>
                    <center>
                        <div>
                            <img src="web/<%=System.Web.HttpUtility.UrlEncode(Tmdb.GetSafeFilename((string)season.name)).Replace("+","%20")+".poster"+ext%>" alt="<%=season.name%>" style="width: 100%" />
                        </div>
                    </center>

                    <%} %>
                    <h3><%=season.name %></h3>
                    <% if((double)season.vote_average!=double.NaN && (double)season.vote_average>0.0) {%>
                    <div>
                        <span class="stars"><% 
			double avg = ((double)season.vote_average)/2.0;
			for(int ri = 0;ri<5;++ri) {
				if(Math.Round(avg)>ri) {
					Response.Write("★");
				} else {
					Response.Write("☆");
				}
			}
                        %></span><span><%=" "+(Math.Round(avg*10)/10.0).ToString() %></span>
                    </div>
                    <% } %>
                    <%if(!string.IsNullOrEmpty(season.overview as string)) { %>
                    <center>
                        <p style="margin-bottom: 20px"><%=season.overview %></p>
                    </center>
                    <%} %>
                </div>
            </a>
            <%
            if(3==(sidx%4)) {
            %>
        </div>
        <% 
            }
            ++sidx;
        }
        %>
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
