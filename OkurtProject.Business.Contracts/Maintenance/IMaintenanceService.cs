using OkurtProject.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkurtProject.Business.Contracts
{
    public interface IMaintenanceService
    {
        List<MaintenancesDTO> Maintenances();

        MaintenanceDetailResponseDTO MaintenanceDetail(int id);
    }
}
