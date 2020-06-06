using Newtonsoft.Json;

namespace OkurtProject.Client.DTO
{
    public class ApiResponseDTO
    {
        public bool Success { get; set; }
        public object Result { get; set; }
        public string Error { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
