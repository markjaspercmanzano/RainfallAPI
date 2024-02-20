using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public IList<ErrorDetail> Detail { get; set; }
    }
}
