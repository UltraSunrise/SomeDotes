namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Hero
    {
        private List<HeroPlayer> allHeroes;

        [JsonProperty("team2")]
        public RadiantTeamHero RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamHero DireTeam { get; set; }
        public List<HeroPlayer> AllHeroes
        {
            get
            {
                allHeroes = new List<HeroPlayer>();
                allHeroes.AddRange(RadiantTeam.AllPlayers);
                allHeroes.AddRange(DireTeam.AllPlayers);

                return allHeroes;
            }
        }
    }
}
