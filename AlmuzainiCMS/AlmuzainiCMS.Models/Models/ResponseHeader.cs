using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class ResponseHeader
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string sessionId { get; set; }
    }
}
