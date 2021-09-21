using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public interface ILoadKalenderUseCase
    {
        Kalender Execute(int underviserId, int holdId);
    }
}