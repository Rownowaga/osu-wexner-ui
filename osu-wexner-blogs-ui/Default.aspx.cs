using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using osu_wexner_blogs_ui.App_Code;

namespace osu_wexner_blogs_ui
{
    public partial class Default : System.Web.UI.Page
    {
        private static string titleEndpoint = "";
        private static string detailEndpoint = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlBlogTitles.Items.Add("");
                foreach(BlogTitle title in loadTitles())
                {
                    ddlBlogTitles.Items.Add(title.Title);
                }
            }
        }

        protected List<BlogTitle> loadTitles()
        {
            List<BlogTitle> list = new List<BlogTitle>();
            Console.WriteLine(BlogTitle.getTitles(titleEndpoint));

            return list;
        }

        protected void filterBlogDetails(object sender, EventArgs e)
        {

        }
    }
}