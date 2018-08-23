using SomeDotes.Services.RealTimeService;

namespace SomeDotes.Models.Interfaces
{
    interface ICurrentGameService
    {
        bool Start();
        event NewGameStateHandler NewGameState;
    }
}
