using gym.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Models.Json
{
    public class JudgeJson
    {
        [JsonProperty(PropertyName = "id")]
        public int JsonId { get; set; }
        [JsonProperty(PropertyName = "preferredfirstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "preferredlastname")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [JsonProperty(PropertyName = "nfcountry")]
        public string Country { get; set; }
        public Discipline Discipline { get; set; }
        public int Category { get; set; }
        public DateTime Birth { get; set; }
    }
}
