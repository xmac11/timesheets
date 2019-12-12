using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            return (DateTime) date >= new DateTime(DateTime.Now.Year, 1, 1) &&
                (DateTime) date <= DateTime.Now;
        }
    }
}
