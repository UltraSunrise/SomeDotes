namespace SomeDotes.Helpers
{
    public class HeroWinPercentageHelper
    {
        public int HeroId { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public decimal WinChance { get; set; }
        public string HeroImage { get; set; }
    }
}
