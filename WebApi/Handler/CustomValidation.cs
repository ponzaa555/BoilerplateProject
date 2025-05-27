using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Handler
{
    public class CustomValidation : ValidationException
    {
        public Dictionary<string , string[]> Errors { get; }

        public CustomValidation(string message , ModelStateDictionary modelState) : base(message)
        {
            Errors = MapModelStateErrors(modelState);
        }

        private Dictionary<string , string[]> MapModelStateErrors (ModelStateDictionary modelState)
        {
            return modelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
        }
    }
}