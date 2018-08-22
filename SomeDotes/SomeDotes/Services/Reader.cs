namespace SomeDotes.Services
{
    using Newtonsoft.Json;
    using SomeDotes.Data.Entities;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Services.DatabaseServices;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    
    public class Reader
    {
        IDatabaseService dbService = new DatabaseService();
        long tempId = 4072941891;

        public async System.Threading.Tasks.Task ReadXMLAsync()
        {
            List<Result> results = new List<Result>();

            while(tempId > 4000000000)
            {
                var req = WebRequest.Create(string.Format(@"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id={0}&key=771F6AEA67F1913B60DB7A66FFB3DE3C", tempId.ToString()));
                var r = await req.GetResponseAsync().ConfigureAwait(false);

                var responseReader = new StreamReader(r.GetResponseStream());
                var responseData = await responseReader.ReadToEndAsync();

                Result result = JsonConvert.DeserializeObject<RootObject>(responseData).Result;
                tempId--;

                if (result.Duration < 360 && result.LobbyType != 7)
                    continue;

                results.Add(result);
            }

            dbService.AddRangeJSONToDatabase(results);
        }
    }
}
