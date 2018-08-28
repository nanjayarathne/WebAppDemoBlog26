using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppDemoBlog26.Common
{
    public class CurrentDateValidateAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Convert.ToDateTime(value) <= DateTime.Now;
        }
    }
}