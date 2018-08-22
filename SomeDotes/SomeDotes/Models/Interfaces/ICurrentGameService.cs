using SomeDotes.Services.LifetimeServices;

namespace SomeDotes.Models.Interfaces
{
    interface ICurrentGameService
    {
        bool Start();
        event NewGameStateHandler NewGameState;
    }
}
