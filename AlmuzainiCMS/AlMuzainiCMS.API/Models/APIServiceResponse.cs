
namespace AlMuzainiCMS.API.Models
{
    public class APIServiceResponse
    {
        public string ResponseDateTime { get; set; }
        public bool ResponseStatus { get; set; }
        public string SuccessMsg { get; set; }
        public int ResponseCode { get; set; }
        public string ErrMsg { get; set; }
        public string RequestDateTime { get; set; }
        public string ResponseBusinessData { get; set; }

        
    }
}
