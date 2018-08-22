using Newtonsoft.Json;

namespace SomeDotes.Data.Entities
{
    public class RootObject
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
