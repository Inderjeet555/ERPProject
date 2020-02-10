using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ERPProject.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// Adds a model errors for each validation result from the business service.
        /// </summary>
        /// <param name="validationResults">The validation results from a business service.</param>
        /// <param name="modelState">The model state dictionary used to add errors.</param>
        /// <param name="defaultErrorKey">The default key to use if a field is not specified in a business service validation result.</param>
        public static void AddModelErrors(this ModelStateDictionary modelState, ValidationException validationException, string defaultErrorKey = null)
        {
            if (validationException.Errors == null) return;

            foreach (ValidationResult vr in validationException.Errors)
            {
                string key = vr.MemberName ?? defaultErrorKey ?? string.Empty;
                modelState.AddModelError(key, vr.Message);
            }
        }

        public static readonly string ErrorMessageKey = "ErrorMessageKey";

        public static void AddErrorMessage(this ModelStateDictionary modelState, string message)
        {
            modelState.AddModelError(ErrorMessageKey, message);
        }

        public static Dictionary<string, string> GetModelStateErrors(this ModelStateDictionary modelState)
        {
            return modelState.Where(x => x.Value.Errors.Any())
                    .ToDictionary(x => x.Key, x => x.Value.Errors.First().ErrorMessage);
        }
    }
}