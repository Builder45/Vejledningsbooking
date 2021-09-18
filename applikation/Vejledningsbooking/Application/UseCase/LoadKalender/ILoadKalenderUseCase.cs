using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public interface ILoadKalenderUseCase
    {
        Kalender Execute(int underviserId, int holdId);
    }
}