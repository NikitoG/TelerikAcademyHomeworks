using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JasonProcessingInDotNet
{
    class JsonProcessing
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var xmlFilePath = "../../Files/video.xml";
            GetContentFromGivenFeed(rssUrl, xmlFilePath);

            var json = ParseXmlToJson(xmlFilePath);
            var jsonObj = JObject.Parse(json);

            GetAllVideoTitles(jsonObj);

            var videos = GetVideosFromJson(jsonObj);

            CreateHtmlFromPoco(videos);
        }

        private static void CreateHtmlFromPoco(IEnumerable<Video> videos)
        {
            var html = new StringBuilder();

            html.Append(@"<!DOCTYPE html>

                        <html>
                        <head>
                            <meta charset=""utf-8"">
                            <title>Telerik Video Chanel</title>
                            <style>
                                div {
                                    height: 400px;
                                    width: 400px;
                                    border: 1px solid black;
                                    border-radius: 10px;
                                    padding: 10px;
                                    margin: 20px;
                                    float:left;
                                }
                                iframe {
                                    margin: 10px;
                                }
                            </style>
                        </head>
                        <body>
                            <h1>Telerik Academy video chanel</h1>");

            foreach(var video in videos)
            {
                html.AppendFormat(@"<div class=""well bold"">
                                        Видео към лекцията <strong>""{0}""</strong>.<br>
                                        Адрес на видеото в YouTube: <a href=""{1}"" target=""_blank"" title=""Видео"">{1}</a>
                                        <iframe width=""380"" height=""300"" id=""lecture-video"" src=""https://www.youtube.com/embed/{2}?enablejsapi=1&amp;version=3"" enablejsapi=""1"" allowfullscreen=""""></iframe>
                                    </div>", video.Title, video.Link.Href, video.Id);
            }

            html.Append(@"</body>
                        </html>");

            var htmlFilePath = "../../Files/videos.html";
            using(StreamWriter writer = new StreamWriter(htmlFilePath))
            {
                writer.Write(html.ToString());
            }

            Console.WriteLine("Result in videos.html");
        }

        private static IEnumerable<Video> GetVideosFromJson(JObject jsonObj)
        {
            var videos = jsonObj["feed"]["entry"].Select(video => JsonConvert.DeserializeObject<Video>(video.ToString()));

            return videos;
        }

        private static void GetAllVideoTitles(JObject jsonObj)
        {
            var index = 1;
            var allTitle = jsonObj["feed"]["entry"].Select(video => string.Format("{0}. {1}", index++, video["title"]));
            Console.WriteLine(string.Join(", ", allTitle));
        }

        private static string ParseXmlToJson(string xmlFilePath)
        {
            var doc = XDocument.Load(xmlFilePath);
            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            var jsonFilePath = "../../Files/video.txt";
            using (StreamWriter writer = new StreamWriter(jsonFilePath))
            {
                writer.Write(json);
            }

            Console.WriteLine("Parse xml to JSON completed. Result is in video.txt");
            return json;
        }

        private static void GetContentFromGivenFeed(string rssUrl, string xmlFilePath)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(rssUrl, xmlFilePath);

            Console.WriteLine("Content is in video.xml");
        }
    }
}
