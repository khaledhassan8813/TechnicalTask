using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UnifiedDataModel
    {
        [JsonPropertyName("first name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last name")]
        public string LastName { get; set; }
        [JsonPropertyName("telephone code")]
        public string TelephoneCode { get; set; }
        [JsonPropertyName("telephone number")]
        public string TelephoneNumber { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
