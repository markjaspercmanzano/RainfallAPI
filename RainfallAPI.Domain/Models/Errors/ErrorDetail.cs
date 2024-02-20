using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.Errors
{
    public class ErrorDetail
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
