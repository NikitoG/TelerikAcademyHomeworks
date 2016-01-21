using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloPageAspx
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonName_Click(object sender, EventArgs e)
        {
            var name = this.TextBoxName.Text;
            this.LabelSayHello.Text = string.Format("Hello {0}!", name);
        }
    }
}