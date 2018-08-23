namespace SomeDotes.Services.RealTimeService
{
    using Newtonsoft.Json.Linq;
    using SomeDotes.Models.Interfaces;

    public class CurrentGameStateService : ICurrentGameStateService
    {
        private JObject parseData;
        private string json;

        public CurrentGameStateService(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                jsonData = "{}";
            }

            json = jsonData;
            parseData = JObject.Parse(json);
        }


    }
}