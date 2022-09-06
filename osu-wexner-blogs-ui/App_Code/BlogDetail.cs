using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace osu_wexner_blogs_ui.App_Code
{

    public class BlogDetails
    {

        public string uuid { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string authorName { get; set; }
        public string topic { get; set; }
        public long readTime { get; set; }
        public int clicks { get; set; }

        public DateTime publishDate { get; set; }

        public static string loadDetails()
        {
            string html = string.Empty;
            string url = @"https://localhost:7238/BlogDetails";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                html = reader.ReadToEnd();

            return html;
        }

        public static string loadFilteredDetails(string topic)
        {
            string html = string.Empty;
            string url = @"https://localhost:7238/BlogDetails/" + topic;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                html = reader.ReadToEnd();

            return html;
        }
    }
}