using OkurtProject.Business.Contracts;
using OkurtProject.Business.DTO;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Data.Contracts;
using System.Linq;

namespace OkurtProject.Business
{
    public class MaintenanceService : BaseService, IMaintenanceService
    {
        public MaintenanceService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public List<MaintenancesDTO> Maintenances()
        {
            var maintenances = _serviceProvider.GetService<IMaintenanceRepository>().Get();

            List<MaintenancesDTO> result = new List<MaintenancesDTO>();

            if (maintenances != null)
            {
                foreach (var item in maintenances)
                {
                    result.Add(new MaintenancesDTO() { Description = item.Description });
                }
            }

            return result;
        }

        public MaintenanceDetailResponseDTO MaintenanceDetail(int id)
        {
            var maintenance = _serviceProvider.GetService<IMaintenanceRepository>().GetByID(id);

            return new MaintenanceDetailResponseDTO()
            {
                Description = maintenance.Description
            };
        }
    }
}
