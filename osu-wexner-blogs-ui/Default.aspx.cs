using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using osu_wexner_blogs_ui.App_Code;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace osu_wexner_blogs_ui
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlBlogTitles.Items.Add(new ListItem("", ""));
                loadTitles(sender, e);
                if (ddlBlogTitles.Items.Count > 1)
                { loadAllDetails(sender, e); }

            }
        }

        protected void loadTitles(object sender, EventArgs e)
        {
            string titleContent = string.Empty;
            try
            {
                titleContent = BlogTitle.loadTitles();
            }
            catch (Exception ex)
            {
                titleContent = File.ReadAllText(HttpContext.Current.Server.MapPath("App_Code/DummyTitles.json"));
            }
            BlogTitle[] titleList = JsonConvert.DeserializeObject<BlogTitle[]>(titleContent);
            foreach (BlogTitle title in titleList)
                ddlBlogTitles.Items.Add(new ListItem(title.Name, title.Name));
        }

        protected void loadAllDetails(object sender, EventArgs e)
        {
            string detailContent = string.Empty;

            detailContent = BlogDetails.loadDetails();
            BlogDetails[] details = JsonConvert.DeserializeObject<BlogDetails[]>(detailContent);
            loadLiteral(details);
        }

        protected void filterBlogDetails(object sender, EventArgs e)
        {
            string detailContent = string.Empty;

            detailContent = BlogDetails.loadFilteredDetails(ddlBlogTitles.SelectedItem.Text);
            BlogDetails[] details = JsonConvert.DeserializeObject<BlogDetails[]>(detailContent);
            loadLiteral(details);
        }

        protected void loadLiteral(BlogDetails[] details)
        {
            StringBuilder detailTable = new StringBuilder();

            detailTable.AppendLine("<table cellpadding=\"10\" style=\"width:100%\">");
            detailTable.AppendLine("<tr class=\"paddedRow\">");
            int newRow = 1;
            foreach (BlogDetails detail in details)
            {
                detailTable.AppendLine("<td class=\"blogCardCell\">");
                detailTable.AppendLine("<table class=\"blogCard\"><tr>");
                detailTable.AppendLine("<td colspan=\"3\"><a href=\"#\">" + detail.title + "</a></td>");
                detailTable.AppendLine("</tr><tr>");
                detailTable.AppendLine("<td style=\"padding-bottom:10px;\" colspan=\"2\"><i> " + detail.desc + "</i></td>");
                detailTable.AppendLine("</tr><tr>");
                detailTable.AppendLine("<td style=\"padding-bottom: 15px;\" colspan=\"2\">By: <b>" + detail.authorName + "</br></td>");
                detailTable.AppendLine("<td style=\"padding-bottom: 15px;\">Published: <b>" + detail.publishDate.ToShortDateString() + "</br></td>");
                detailTable.AppendLine("</tr><tr>");
                detailTable.AppendLine("<td>Clicks: <b>" + detail.clicks + "</b></td>");
                detailTable.AppendLine("<td>Read Time: <b>" + detail.readTime + "min</b></td>");
                detailTable.AppendLine("<td>Topic: <b>" + detail.topic + "</b></td>");
                detailTable.AppendLine("</tr>");
                detailTable.AppendLine("</table>");
                if (newRow % 2 == 0)
                    detailTable.AppendLine("</tr><tr class=\"paddedRow\">");

                newRow++;
            }
            detailTable.AppendLine("</tr>");
            detailTable.AppendLine("</table>");
            litDetails.Text = detailTable.ToString();
        }
    }
}