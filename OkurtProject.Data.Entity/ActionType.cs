using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("ActionType")]
    public class ActionType : BaseEntity
    {
        public string Name { get; set; }
    }
}
