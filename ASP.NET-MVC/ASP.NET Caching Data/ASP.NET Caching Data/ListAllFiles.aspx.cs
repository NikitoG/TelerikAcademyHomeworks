using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Caching_Data
{
    public partial class ListAllFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var directoryName = Server.MapPath("\\Common");

            DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
            string[] filenames = dirInfo.GetFiles().Select(i => i.Name).ToArray();
            string[] fullNames = dirInfo.GetFiles().Select(i => i.FullName).ToArray();

            if (this.Cache["files"] == null)
            {
                var dependency = new CacheDependency(fullNames);
                var content = string.Join(", ", filenames) + DateTime.Now;
                Cache.Insert(
                    "files",                    // key
                    content,                   // object
                    dependency,                // dependencies
                    DateTime.Now.AddHours(1),  // absolute exp.
                    TimeSpan.Zero,             // sliding exp.
                    CacheItemPriority.Default, // priority
                    null);                     // callback delegate
            }

            this.filePathSpan.InnerText = string.Join(", ", filenames) + DateTime.Now;
            this.currentTimeSpan.InnerText = this.Cache["files"] as string;
        }
    }
}