using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var input = this.TextBoxInput.Text;
            this.LabelOutput.Text = Server.HtmlEncode(input);
            this.TextBoxOutput.Text = input;
        }
    }
}