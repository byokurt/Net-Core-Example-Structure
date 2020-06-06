using OkurtProject.Client.DTO;
using System;
using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OkurtProject.Client.API.Controllers
{
    [Route("maintenance")]
    public class MaintenanceController : BaseUserController
    {
        public MaintenanceController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        [Route("list")]
        public List<MaintenancesResponseDTO> List()
        {
            var maintenances = _serviceProvider.GetService<IMaintenanceService>().Maintenances();

            var result = new List<MaintenancesResponseDTO>() { };

            foreach (var item in maintenances)
            {
                result.Add(new MaintenancesResponseDTO()
                {
                    Description = item.Description
                });
            }

            return result;
        }


        [HttpGet]
        [Route("detail")]
        public MaintenanceDetailResponseDTO Detail(int id)
        {
            var result = _serviceProvider.GetService<IMaintenanceService>().MaintenanceDetail(id);

            return new MaintenanceDetailResponseDTO()
            {
                Description = result.Description
            };
        }
    }
}