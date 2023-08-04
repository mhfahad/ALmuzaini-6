using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class CurrencyRequest
    {
        public Guid Id { get; set; }
        public string RequestId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SessionId { get; set; }
    }
}
