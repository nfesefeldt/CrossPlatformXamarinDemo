using Newtonsoft.Json;
using System.Collections.Generic;
namespace XamarinDemo.Models
{
    public class Android
    {
        [JsonProperty(PropertyName = "analyticsTrackingCode")]
        public string AnalyticsTrackingCode { get; set; }

        [JsonProperty(PropertyName = "minimumVersion")]
        public string MinimumVersion { get; set; }

        [JsonProperty(PropertyName = "currentVersion")]
        public string CurrentVersion { get; set; }

        [JsonProperty(PropertyName = "clientActions")]
        public ClientAction ClientActions { get; set; }

        [JsonProperty(PropertyName = "featureFlags")]
        public FeatureFlag FeatureFlags { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<string> Messages { get; set; }
    }
}
