namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class DireSubPlayer
    {
        [JsonProperty("steamid")]
        public string SteamId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("activity")]
        public string Activity { get; set; }
        [JsonProperty("kills")]
        public long Kills { get; set; }
        [JsonProperty("deaths")]
        public long Death { get; set; }
        [JsonProperty("assists")]
        public long Assists { get; set; }
        [JsonProperty("last_hits")]
        public long LastHits { get; set; }
        [JsonProperty("denies")]
        public long Denies { get; set; }
        [JsonProperty("kill_streak")]
        public long KillStreak { get; set; }
        [JsonProperty("commands_issued")]
        public long CommandIssued { get; set; }
        [JsonProperty("kill_list")]
        public DireKillList KillList { get; set; }
        [JsonProperty("team_name")]
        public string TeamName { get; set; }
        [JsonProperty("gold")]
        public long Gold { get; set; }
        [JsonProperty("gold_reliable")]
        public long GoldReliable { get; set; }
        [JsonProperty("gold_unreliable")]
        public long GoldUnrealiable { get; set; }
        [JsonProperty("gold_from_hero_kills")]
        public long GoldFromHeroKills { get; set; }
        [JsonProperty("gold_from_creep_kills")]
        public long GoldFromCreepKills { get; set; }
        [JsonProperty("gold_from_income")]
        public long GoldFromIncome { get; set; }
        [JsonProperty("gold_from_shared")]
        public long GoldFromShared { get; set; }
        [JsonProperty("gpm")]
        public long GoldPerMinute { get; set; }
        [JsonProperty("xpm")]
        public long XpPerMinute { get; set; }
        [JsonProperty("net_worth")]
        public long NetWorth { get; set; }
        [JsonProperty("hero_damage")]
        public long HeroDamage { get; set; }
        [JsonProperty("wards_purchased")]
        public long WardsPurchased { get; set; }
        [JsonProperty("wards_placed")]
        public long WardsPlaced { get; set; }
        [JsonProperty("wards_destroyed")]
        public long WardsDestroyed { get; set; }
        [JsonProperty("runes_activated")]
        public long RunesActivated { get; set; }
        [JsonProperty("camps_stacked")]
        public long CampsStacked { get; set; }
        [JsonProperty("support_gold_spent")]
        public long SupportGoldSpent { get; set; }
        [JsonProperty("consumable_gold_spent")]
        public long ConsumableGoldSpent { get; set; }
        [JsonProperty("item_gold_spent")]
        public long ItemGoldSpent { get; set; }
        [JsonProperty("gold_lost_to_death")]
        public long GoldLostToDeath { get; set; }
        [JsonProperty("gold_spent_on_buybacks")]
        public long GoldSpentOnBuybacks { get; set; }
    }
}
