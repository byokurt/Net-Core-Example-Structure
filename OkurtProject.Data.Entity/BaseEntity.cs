using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    public class BaseEntity
    {
        [Column("ID", Order = 0)]
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual int? ModifiedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
