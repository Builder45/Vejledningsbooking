using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public class IndlæsKalenderCommand : IIndlæsKalenderCommand
    {
        private IDatabaseService _dbService;

        public IndlæsKalenderCommand(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        public IKalender Execute(int underviserId, int holdId)
        {
            return _dbService.LoadKalender(underviserId, holdId);
        }
    }
}
