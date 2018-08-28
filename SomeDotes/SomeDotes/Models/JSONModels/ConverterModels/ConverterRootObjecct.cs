namespace SomeDotes.Models.JSONModels.ConverterModels
{
    using Newtonsoft.Json;

    public class ConverterRootObjecct
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
