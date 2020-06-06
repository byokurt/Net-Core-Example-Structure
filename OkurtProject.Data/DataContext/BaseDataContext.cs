using Microsoft.EntityFrameworkCore;
using OkurtProject.Data.Contracts;
using OkurtProject.Data.Entity;

namespace OkurtProject.Data
{
    public abstract class BaseDataContext : DbContext, IBaseDataContext
    {
        public BaseDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ActionType> SetActionType { get; set; }
        public DbSet<Maintenance> SetMaintenance { get; set; }
        public DbSet<MaintenanceHistory> SetMaintenanceHistory { get; set; }
        public DbSet<PictureGroup> SetPictureGroup { get; set; }
        public DbSet<Status> SetStatus { get; set; }
        public DbSet<User> SetUser { get; set; }
        public DbSet<Vehicle> SetVehicle { get; set; }
        public DbSet<VehicleType> SetVehicleType { get; set; }
    }
}
