namespace SomeDotes.Models.JSONModels
{
    public class SubPlayer
    {
        public string SteamId { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public long Kills { get; set; }
        public long Death { get; set; }
        public long Assists { get; set; }
        public long LastHits { get; set; }
        public long Denies { get; set; }
        public long KillStreak { get; set; }
        public long CommandIssued { get; set; }
        public RadiantKillList KillList { get; set; }
        public string TeamName { get; set; }
        public long Gold { get; set; }
        public long GoldReliable { get; set; }
        public long GoldUnrealiable { get; set; }
        public long GoldFromHeroKills { get; set; }
        public long GoldFromCreepKills { get; set; }
        public long GoldFromIncome { get; set; }
        public long GoldFromShared { get; set; }
        public long GoldPerMinute { get; set; }
        public long XpPerMinute { get; set; }
        public long NetWorth { get; set; }
        public long HeroDamage { get; set; }
        public long WardsPurchased { get; set; }
        public long WardsPlaced { get; set; }
        public long WardsDestroyed { get; set; }
        public long RunesActivated { get; set; }
        public long CampsStacked { get; set; }
        public long SupportGoldSpent { get; set; }
        public long ConsumableGoldSpent { get; set; }
        public long ItemGoldSpent { get; set; }
        public long GoldLostToDeath { get; set; }
        public long GoldSpentOnBuybacks { get; set; }
    }
}
