namespace SomeDotes.Models.Interfaces
{
    using MainModels;

    interface IRegisterCurrentGameService
    {
        void Run();
        CurrentGameInfo MatchInfo();
    }
}