using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Webapi.Helpers
{
    public class ModelStateError
    {
        public static IEnumerable<ModelErrorCollection> GetErrors(ModelStateDictionary dictionary)
        {
            var errors = new List<ModelErrorCollection>();

            foreach (var value in dictionary.Values)
            {
                errors.Add(value.Errors);
            }

            return errors;
        }
    }
}
