using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonProcessingInDotNet
{
    class URL
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
