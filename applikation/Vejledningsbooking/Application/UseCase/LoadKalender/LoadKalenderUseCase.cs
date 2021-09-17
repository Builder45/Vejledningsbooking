using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public class LoadKalenderUseCase : ILoadKalenderUseCase
    {
        private IDatabaseService _dbService;

        public LoadKalenderUseCase(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        public IKalender Execute(int underviserId, int holdId)
        {
            return _dbService.LoadKalender(underviserId, holdId);
        }
    }
}
