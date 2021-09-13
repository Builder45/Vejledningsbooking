using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public interface IIndlæsKalenderCommand
    {
        IKalender Execute(int underviserId, int holdId);
    }
}