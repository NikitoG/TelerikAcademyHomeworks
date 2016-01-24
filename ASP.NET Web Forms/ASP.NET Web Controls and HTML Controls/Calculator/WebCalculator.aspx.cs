using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class WebCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "1";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            this.TextBoxScreen.Text += "2";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "3";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "4";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "5";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "6";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "7";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "8";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "9";
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.LabelScreen.Text = "";
            this.TextBoxScreen.Text = "";
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            var aritmetics = this.LastAritmetics();
            if (!String.IsNullOrWhiteSpace(aritmetics) && !String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.GetCurrentResult(aritmetics);
            }
            else if (!String.IsNullOrWhiteSpace(aritmetics) && String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.TextBoxScreen.Text = label[0];
            }

            this.LabelScreen.Text = this.TextBoxScreen.Text + " + ";
            this.TextBoxScreen.Text = "";
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            var aritmetics = this.LastAritmetics();
            if (!String.IsNullOrWhiteSpace(aritmetics) && !String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.GetCurrentResult(aritmetics);
            }
            else if (!String.IsNullOrWhiteSpace(aritmetics) && String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.TextBoxScreen.Text = label[0];
            }

            this.LabelScreen.Text = this.TextBoxScreen.Text + " - ";
            this.TextBoxScreen.Text = "";
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            var aritmetics = this.LastAritmetics();
            if (!String.IsNullOrWhiteSpace(aritmetics) && !String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.GetCurrentResult(aritmetics);
            }
            else if (!String.IsNullOrWhiteSpace(aritmetics) && String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.TextBoxScreen.Text = label[0];
            }

            this.LabelScreen.Text = this.TextBoxScreen.Text + " / ";
            this.TextBoxScreen.Text = "";
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            var aritmetics = this.LastAritmetics();
            if (!String.IsNullOrWhiteSpace(aritmetics) && !String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.GetCurrentResult(aritmetics);
            }
            else if (!String.IsNullOrWhiteSpace(aritmetics) && String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.TextBoxScreen.Text = label[0];
            }

            this.LabelScreen.Text = this.TextBoxScreen.Text + " X ";
            this.TextBoxScreen.Text = "";
        }

        protected void ButtonSquareRoot_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.LabelScreen.Text = "";
                this.TextBoxScreen.Text = Math.Sqrt(double.Parse(this.TextBoxScreen.Text)).ToString();
            }
            else if(String.IsNullOrWhiteSpace(this.TextBoxScreen.Text) && !string.IsNullOrWhiteSpace(this.LabelScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.LabelScreen.Text = "";
                this.TextBoxScreen.Text = Math.Sqrt(double.Parse(label[0])).ToString();
            }
        }

        protected void ButtonEqual_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.TextBoxScreen.Text) && !string.IsNullOrWhiteSpace(this.LabelScreen.Text))
            {
                var aritmetics = this.LastAritmetics();
                this.GetCurrentResult(aritmetics);
                this.LabelScreen.Text = "";
            }
            else if(!string.IsNullOrWhiteSpace(this.LabelScreen.Text))
            {
                var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.TextBoxScreen.Text = label[0];            }
        }

        private void GetCurrentResult(string aritmetics)
        {
            var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (aritmetics.ToLower())
            {
                case "+": this.TextBoxScreen.Text = (double.Parse(label[0]) + double.Parse(this.TextBoxScreen.Text)).ToString(); break;
                case "-": this.TextBoxScreen.Text = (double.Parse(label[0]) - double.Parse(this.TextBoxScreen.Text)).ToString(); break;
                case "x": this.TextBoxScreen.Text = (double.Parse(label[0]) * double.Parse(this.TextBoxScreen.Text)).ToString(); break;
                case "/": this.TextBoxScreen.Text = (double.Parse(label[0]) / double.Parse(this.TextBoxScreen.Text)).ToString(); break;
            }

            this.LabelScreen.Text += this.TextBoxScreen.Text;
        }

        private string LastAritmetics()
        {
            var aritmetics = "";
            var label = this.LabelScreen.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (label.Length > 1)
            {
                aritmetics = label[label.Length - 1];
            }

            return aritmetics;
        }
    }
}