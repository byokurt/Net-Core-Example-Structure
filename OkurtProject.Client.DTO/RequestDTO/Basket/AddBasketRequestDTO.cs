using System;

namespace OkurtProject.Client.DTO
{
    public class AddBasketRequestDTO
    {
        public Guid? UniqId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
