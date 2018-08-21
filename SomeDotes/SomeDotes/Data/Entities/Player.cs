namespace SomeDotes.Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public short PlayerSlot { get; set; }
        public short HeroId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
