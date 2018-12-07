namespace SomeDotes.Models.Interfaces
{
    using SomeDotes.ViewModels;

    public interface IPreGameStatisticsService
    {
        void Run();
        PreGameViewModel PreGameViewModel { get; set; }
    }
}
