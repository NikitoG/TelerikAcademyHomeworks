using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace InformationalSite.Areas.User.Models
{
    public class ArticleViewModel
    {
        public int id { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }
    }
}