using System;

namespace OkurtProject.Business.DTO
{
    public class UserAuthenticationResultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
