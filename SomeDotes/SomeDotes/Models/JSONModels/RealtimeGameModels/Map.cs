namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class Map
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("matchid")]
        public long MatchId { get; set; }
        [JsonProperty("game_time")]
        public long GameTime { get; set; }
        [JsonProperty("clock_time")]
        public long ClockTime { get; set; }
        [JsonProperty("daytime")]
        public bool DayTime { get; set; }
        [JsonProperty("nightstalker_night")]
        public bool NightStalkerNight { get; set; }
        [JsonProperty("game_state")]
        public string GameState { get; set; }
        [JsonProperty("paused")]
        public bool Paused { get; set; }
        [JsonProperty("win_team")]
        public string WinTeam { get; set; }
        [JsonProperty("customgamename")]
        public string CustomGameName { get; set; }
        [JsonProperty("radiant_ward_purchase_cooldown")]
        public long RadiantWardPurchaseCooldown { get; set; }
        [JsonProperty("dire_ward_purchase_cooldown")]
        public long DireWardPurchaseCooldown { get; set; }
        [JsonProperty("roshan_state")]
        public string RoshanState { get; set; }
        [JsonProperty("roshan_state_end_seconds")]
        public long RoshanStateEndSeconds { get; set; }
        [JsonProperty("radiant_win_chance")]
        public long RadiantWinChance { get; set; }
    }
}
