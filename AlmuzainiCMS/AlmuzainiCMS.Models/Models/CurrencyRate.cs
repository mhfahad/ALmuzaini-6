using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class CurrencyRate
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
        public double Rate { get; set; }
        public double LCAmount { get; set; }
        public double FCAmount { get; set; }
    }
}
