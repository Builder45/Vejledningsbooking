using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public class LoadKalenderUseCase : ILoadKalenderUseCase
    {
        private IDatabaseService _dbService;

        public LoadKalenderUseCase(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        public Kalender Execute(int underviserId, int holdId)
        {
            return _dbService.LoadKalender(underviserId, holdId);
        }
    }
}
