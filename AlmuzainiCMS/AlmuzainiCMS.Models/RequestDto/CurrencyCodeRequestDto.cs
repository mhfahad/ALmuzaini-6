using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class CurrencyCodeRequestDto
    {
        public Guid? Id { get; set; }
        public string CurrencyCodeName { get; set; }
        public string? flagPath { get; set; }
        public IFormFile? FlagFile { get; set; }
    }
}
