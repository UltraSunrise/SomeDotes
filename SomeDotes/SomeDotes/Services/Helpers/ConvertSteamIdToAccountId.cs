namespace SomeDotes.Services.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.JSONModels.ConverterModels;

    public class ConvertSteamIdToAccountId : IConvertSteamIdToAccountId
    {
        public string SingleId(string steamId)
        {
            string json = string.Empty;

            try
            {
                // Sending request for current player's history matches
                WebResponse response;
                WebRequest request = WebRequest.Create(string.Format(@"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key=771F6AEA67F1913B60DB7A66FFB3DE3C&account_id={0}&Matches_Requested=100", steamId));

                response = request.GetResponse();

                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                json = responseReader.ReadToEnd();
            }
            catch (WebException)
            {
                SingleId(steamId);
            }

            List<string> accountIds = new List<string>();
            Dictionary<string, int> steamIds = new Dictionary<string, int>();

            // Parsing current json for every player so we can find AccountId and take records from DB
            var currentMatches = JsonConvert.DeserializeObject<ConverterRootObjecct>(json).Result.Matches;

            // Checking which player took part in all games
            foreach (var match in currentMatches)
            {
                foreach (var player in match.Players)
                {
                    string currentPlayerAccountId = player.AccountId.ToString();

                    if (!steamIds.ContainsKey(currentPlayerAccountId))
                        steamIds.Add(currentPlayerAccountId, 0);
                    else
                        steamIds[currentPlayerAccountId]++;
                }
            }

            // Ordering all players so we can find the one with most games out of these
            string playerAccountId = steamIds.OrderBy(v => v.Value).LastOrDefault().Key;

            // Returning player's AccountId
            return playerAccountId;
        }
    }
}
