using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace UniQode.Web.Extensions
{
    public static class McvExtensions
    {
        public static void ValidateViewModel<TViewModel, TController>(this TController controller,
            TViewModel viewModelToValidate)
            where TController : Controller
        {
            var validationContext = new ValidationContext(viewModelToValidate, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(viewModelToValidate, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty,
                    validationResult.ErrorMessage);
            }
        }

        public static IDictionary<string, string[]> ToSerializableDictionary(this ModelStateDictionary modelState)
        {
            return modelState.Where(x => x.Value.Errors.Any()).ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
        }
    }
}