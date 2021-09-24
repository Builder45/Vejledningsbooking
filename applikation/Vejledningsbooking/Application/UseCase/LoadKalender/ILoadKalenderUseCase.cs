using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public interface ILoadKalenderUseCase
    {
        Kalender LoadKalender(KalenderCommand data);
    }
}