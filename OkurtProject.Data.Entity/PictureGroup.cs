using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("PictureGroup")]
    public class PictureGroup : BaseEntity
    {
        public string PictureImage { get; set; }
    }
}
