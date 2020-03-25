using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Core.Webapi.Models;

namespace Core.Webapi.Attributes
{
    public class RequiredBasedOnModuleAttribute : ValidationAttribute
    {
        private readonly PaymentModule _module;

        public RequiredBasedOnModuleAttribute(PaymentModule module)
        {
            _module = module;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (PaymentModel) validationContext.ObjectInstance;

            if (model.Module == _module && value != null)
            {
                return ValidationResult.Success;
            }

            if (model.Module != _module)
            {
                return ValidationResult.Success;
            }

            var module = model.Module.ToString();
            return new ValidationResult($"{module} Model is required");
        }
    }
}
