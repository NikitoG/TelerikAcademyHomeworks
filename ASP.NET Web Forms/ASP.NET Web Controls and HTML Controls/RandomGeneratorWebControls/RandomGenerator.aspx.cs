using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorWebControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private readonly Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GetRandom_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.MinValue.Text) || String.IsNullOrWhiteSpace(this.MaxValue.Text))
            {
                this.ErrorMessage.Text = "Both min and max value should be numbers!";
            }
            else
            {
                int minValue;
                int maxValue = 0;
                if (!int.TryParse(this.MinValue.Text, out minValue) || !int.TryParse(this.MaxValue.Text, out maxValue))
                {
                    this.ErrorMessage.Text = "Both min and max value should be numbers!";
                }
                else
                {
                    if (minValue < maxValue)
                    {
                        this.Result.Text = this.random.Next(minValue, maxValue + 1).ToString();
                        this.ErrorMessage.Text = "";
                    }
                    else
                    {
                        this.ErrorMessage.Text = "Min calue should be smaller than max value!";
                    }
                }
            }
        }
    }
}