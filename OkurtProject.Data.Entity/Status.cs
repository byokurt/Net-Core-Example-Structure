using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("Status")]
    public class Status : BaseEntity
    {
        public string Name { get; set; }
    }
}
