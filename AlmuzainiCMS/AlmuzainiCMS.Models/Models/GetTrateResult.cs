using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class GetTTRateResult
    {
        public Guid Id { get; set; }
        public string currencyCode { get; set; }
        public string rate { get; set; }
        public string lcAmount { get; set; }
        public string fcAmount { get; set; }
    }
}
