<!DOCTYPE html>
<html>
<%
	dynamic series = Arguments["series"];
	dynamic season = Arguments["season"];
	dynamic config = Arguments["config"];
	var image_base = (string)config.images.secure_base_url;
	var series_dir = (System.IO.DirectoryInfo)Arguments["series_dir"];

%>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../web/w3.css">
    <title><%= season.name %> - <%=series.name%></title>
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

        .eps_link {
            text-decoration: none;
            color: black;
        }

            .eps_link:hover {
                color: black;
            }
    </style>
</head>
<body>
    <!-- Sidebar (hidden by default) -->
    <nav class="w3-sidebar w3-bar-block w3-card w3-top w3-xlarge w3-animate-left" style="display: none; z-index: 2; width: 40%; min-width: 300px" id="mySidebar">
        <a href="../index.html" onclick="w3_close()"
            class="w3-bar-item w3-button"><%=series.name %></a>
        <a href="#episodes" onclick="w3_close()" class="w3-bar-item w3-button">All Episodes</a>
        <%
    foreach(var episode_obj in season.episodes) {
        dynamic episode = episode_obj;
        var eps_href = Tmdb.GetSafeFilename(string.Format("S{0:00}E{1:00} {2}.html",episode.season_number,episode.episode_number,episode.name));
        %>
        <a href="<%=eps_href%>" onclick="w3_close()" class="w3-bar-item w3-button"><%=episode.name%></a>
        <%
    }
        %>
    </nav>
    <div class="w3-top">
        <div class="w3-white w3-xlarge" style="max-width: 1200px; margin: auto">
            <div class="w3-button w3-padding-16 w3-left" onclick="w3_open()">☰</div>
            <% if((double)season.vote_average!=double.NaN && (double)season.vote_average>0.0) {%>
            <div class="w3-right w3-padding-16">
                <span class="stars"><% 
			double avg = ((double)season.vote_average)/2.0;
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
            <div class="w3-center w3-padding-16"><%=season.name%> - <%=series.name%></div>
            <div class="w3-center">
                <span><%=season.episodes.Count %> episode<%=season.episodes.Count!=1?"s":""%></span>
            </div>
            <% if(!string.IsNullOrEmpty(season.overview as string)) { %>
            <div class="w3-white w3-large" style="max-width: 1200px; margin: auto">
                <p><%=season.overview %></p>
            </div>
            <%} %>
        </div>
    </div>
    <div class="w3-main w3-content w3-padding" style="max-width: 1200px; margin-top: 100px">
        <%
        var eidx = 0;
        while(eidx<season.episodes.Count) {
            dynamic episode = season.episodes[eidx];
            var eps_id = string.Format("S{0:00}E{1:00}",episode.season_number,episode.episode_number);
            var eps = eps_id+" "+(string)episode.name;
            if(0==(eidx%4)) {
        %><div class="w3-row-padding w3-padding-16 w3-center" <%=eidx==0?"id=\"episodes\"":""%>>
            <% 
            }
            %>
            <div class="w3-quarter" id="<%=eps_id%>">
                <a class="eps_link" href="<%=System.Web.HttpUtility.UrlEncode(Tmdb.GetSafeFilename( eps+".html")).Replace("+","%20")%>">
                    <% if(!string.IsNullOrEmpty(episode.still_path as string)) {
	var ext = System.IO.Path.GetExtension((string)episode.still_path);
	var ppath = System.IO.Path.Combine(series_dir.FullName,"web");
    var pfn=Tmdb.GetSafeFilename((string)eps+ext);
	ppath = System.IO.Path.Combine(ppath,pfn);
	Tmdb.Download(image_base+"original"+(string)episode.still_path,ppath);
                    %>
                    <center>
                        <div>
                            <img src="../web/<%=System.Web.HttpUtility.UrlEncode(pfn).Replace("+","%20")%>" alt="<%=eps%>" style="width: 100%" />
                        </div>
                    </center>

                    <%} %>
                    <h3><%=episode.name %></h3>
                    <% if((double)episode.vote_average!=double.NaN && (double)episode.vote_average>0.0) {%>
                    <div>
                        <span class="stars"><% 
			double avg = ((double)episode.vote_average)/2.0;
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
                    <%if(!string.IsNullOrEmpty(episode.overview as string)) { %>
                    <p><%=episode.overview %></p>
                    <%} %>
                </a>
            </div>
            <%
            if(3==(eidx%4)) {
            %>
        </div>
        <% 
            }
            ++eidx;
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
