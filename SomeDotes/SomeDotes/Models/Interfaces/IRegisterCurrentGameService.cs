namespace SomeDotes.Models.Interfaces
{
    using MainModels;

    interface IRegisterCurrentGameService
    {
        void Run();
        MatchInfo MatchInfo();
    }
}