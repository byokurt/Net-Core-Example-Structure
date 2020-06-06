using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkurtProject.Data.Entity
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
    }
}
