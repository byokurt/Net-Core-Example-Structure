using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("VehicleType")]
    public class VehicleType : BaseEntity
    {
        public string Name { get; set; }
    }
}
