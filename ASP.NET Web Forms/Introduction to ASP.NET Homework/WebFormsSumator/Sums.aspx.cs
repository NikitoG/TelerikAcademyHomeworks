using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSumator
{
    public partial class Sums : System.Web.UI.Page
    {
        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            var firstNumber = double.Parse(this.TextBoxFirstNumber.Text);
            var secondNumber = double.Parse(this.TextBoxSecondNumber.Text);
            var sum = firstNumber + secondNumber;

            this.TextBoxResult.Text = sum.ToString();
        }
    }
}