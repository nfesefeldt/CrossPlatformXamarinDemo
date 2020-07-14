using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinDemo.Models
{
    public class FeatureFlag : Dictionary<string, bool>
    {
        [JsonIgnore]
        public bool HasMobileWA
        {
            get
            {
                if (this.ContainsKey("mobile_wa"))
                {
                    return this["mobile_wa"] == true;
                }
                return false;
            }
        }
    }
}
