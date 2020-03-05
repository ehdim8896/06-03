using gym.Models.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Models.JsonList
{
    public class JudgeJsonList
    {
        [JsonProperty("value")]
        public IEnumerable<JudgeJson> JudgesList { get; set; }
    }
}
