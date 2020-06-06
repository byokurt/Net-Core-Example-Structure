using OkurtProject.Data.Contracts;
using OkurtProject.Data.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace OkurtProject.Data
{
    public class VehicleTypeRepository : BaseRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
