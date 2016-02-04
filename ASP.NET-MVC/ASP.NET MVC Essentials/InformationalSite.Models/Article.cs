using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationalSite.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }
    }
}