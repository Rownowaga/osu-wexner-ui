using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using RestSharp;


namespace osu_wexner_blogs_ui.App_Code
{
    public class BlogTitle
    {
        public string Name { get; set; }
        public int AggregateCount { get; set; }
        public string Style { get; set; }

        public BlogTitle(string title, int aggregateCount, string style)
        {
            Name = title;
            AggregateCount = aggregateCount;
            Style = style;
        }

        public static string loadTitles()
        {
            string html = string.Empty;
            string url = @"https://wexnermedical.osu.edu/blog/topics?blogId=F88D7CA3-2E58-4A80-AEFE-A0755FCD491D";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                html = reader.ReadToEnd();

            return html;
        }
    }
}