using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterC
{
    public class TweetModelDto
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}
