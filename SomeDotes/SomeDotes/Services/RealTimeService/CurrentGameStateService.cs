namespace SomeDotes.Services.RealTimeService
{
    using Newtonsoft.Json;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.JSONModels;

    public class CurrentGameStateService : ICurrentGameStateService
    {
        private RootObject parsedData;
        private string json;

        public CurrentGameStateService(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                jsonData = "{}";
            }

            json = jsonData;
            parsedData = JsonConvert.DeserializeObject<RootObject>(jsonData);
        }

        public RootObject ParsedData
        {
            get
            {
                return parsedData;
            }
        }
    }
}