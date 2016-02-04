using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalculator.Models
{
    public class BitViewModels
    {
        public double Value { get; set; }

        public Type Type { get; set; }

        public double InBits { get; set; }

        public double InBytes { get; set; }

        public static List<SelectListItem> GetTypeValues()
        {
            var type = new List<SelectListItem>();
            foreach (Type tp in Enum.GetValues(typeof(Type)))
            {
                type.Add(new SelectListItem { Text = tp.ToString(), Value = ((int)tp).ToString() });
            }

            return type;
        }

        public int Kilo { get; set; }

        public static List<SelectListItem> GetKilos()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "1000", Value = "1000" },
                new SelectListItem { Text = "1024", Value = "1024" }
            };
        }

        public void GetInitValues()
        {
            double initValue = this.Value;
            var pow = (int)this.Type;
            if ((int)this.Type % 10 == 0)
            {
                initValue *= 8;
                pow /= 10;
            }

            if (pow != 0)
            {
                this.InBits = initValue * Math.Pow(this.Kilo, pow - 1);
                this.InBytes = initValue * Math.Pow(this.Kilo, pow - 1) / 8;
            }
        }
    }
}