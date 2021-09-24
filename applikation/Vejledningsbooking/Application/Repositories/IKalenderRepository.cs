using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.Repositories
{
    public interface IKalenderRepository
    {
        void CreateKalender(KalenderCommand data);
        Kalender LoadKalender(KalenderCommand data);
        void UpdateKalender(KalenderCommand data);
        void DeleteKalender(KalenderCommand data);
    }
}
