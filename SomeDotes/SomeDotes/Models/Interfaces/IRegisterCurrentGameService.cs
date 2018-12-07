namespace SomeDotes.Models.Interfaces
{
    using MainModels;

    public interface IRegisterCurrentGameService
    {
        void Run();
        CurrentGameInfo MatchInfo();
    }
}