using OkurtProject.Data.Contracts;
using OkurtProject.Data.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using OkurtProject.Business.DTO;

namespace OkurtProject.Data
{
    public class MaintenanceHistoryRepository : BaseRepository<MaintenanceHistory>, IMaintenanceHistoryRepository
    {
        public MaintenanceHistoryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
