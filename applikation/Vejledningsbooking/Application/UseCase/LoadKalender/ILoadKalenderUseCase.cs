using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public interface ILoadKalenderUseCase
    {
        IKalender Execute(int underviserId, int holdId);
    }
}