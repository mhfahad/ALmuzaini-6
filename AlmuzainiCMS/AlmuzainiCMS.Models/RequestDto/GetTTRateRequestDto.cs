using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class GetTTRateRequestDto
    {
        public string CurrenyCode { get; set; }
        public double Amount { get; set; }
        public string CalcType { get; set; }
        public string Entity { get; set; }
    }
}
