using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public class LoadKalenderUseCase : ILoadKalenderUseCase
    {
        private IKalenderRepository _db;

        public LoadKalenderUseCase(IKalenderRepository db)
        {
            _db = db;
        }

        public Kalender LoadKalender(KalenderCommand data)
        {
            return _db.LoadKalender(data);
        }
    }
}
