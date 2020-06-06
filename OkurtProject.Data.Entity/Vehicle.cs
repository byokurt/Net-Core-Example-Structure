using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("Vehicle")]
    public class Vehicle : BaseEntity
    {
        public string PlateNo { get; set; }
        public int VehicleTypeID { get; set; }
        public int UserID { get; set; }
    }
}
