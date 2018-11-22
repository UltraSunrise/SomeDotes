namespace SomeDotes.Data.Entities
{
    using Newtonsoft.Json;

    public class HeroDb
    {
        public int Id { get; set; }
        [JsonProperty("id")]
        public int HeroId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public byte[] ImageFull { get; set; }
        public byte[] ImageOver { get; set; }
    }
}
