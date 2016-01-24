using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorHtmlControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private readonly Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_ServerClick(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(this.MinVaLue.Value) || String.IsNullOrWhiteSpace(this.MaxValue.Value))
            {
                this.ErrorMessage.InnerText = "Both min and max value should be numbers!";
            }
            else
            {
                var minValue = int.Parse(this.MinVaLue.Value);
                var maxValue = int.Parse(this.MaxValue.Value);

                if (minValue < maxValue)
                {
                    this.RandomNumber.Value = this.random.Next(minValue, maxValue + 1).ToString();
                    this.ErrorMessage.InnerText = "";
                }
                else
                {
                    this.ErrorMessage.InnerText = "Min calue should be smaller than max value!";
                }
            }
        }
    }
}