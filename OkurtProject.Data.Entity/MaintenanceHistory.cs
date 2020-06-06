using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("MaintenanceHistory")]
    public class MaintenanceHistory : BaseEntity
    {
        public int MaintenanceID { get; set; }
        public int ActionTypeID { get; set; }
        public string Text { get; set; }
    }
}
