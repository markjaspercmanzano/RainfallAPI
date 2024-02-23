using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.Errors
{
    public class ErrorResponse
    {
        public IList<Error> Errors { get; set; }
    }
}
