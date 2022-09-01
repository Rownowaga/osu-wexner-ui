using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace osu_wexner_blogs_ui.App_Code
{
    public class BlogTitle
    {
        public string Title { get; set; }
        public int AggregateCount { get; set; }
        public string Style { get; set; }

        public BlogTitle(string title, int aggregateCount, string style)
        {
            Title = title;
            AggregateCount = aggregateCount;
            Style = style;
        }

        public static string getTitles(string endpoint)
        {
            HttpWebRequest client = WebRequest.Create(endpoint) as HttpWebRequest;
            client.Method = "GET";
            client.KeepAlive = false;
            client.ContentType = "application/json";
            Stream data = client.GetRequestStream();
            return data.ToString();
        }
    }
}