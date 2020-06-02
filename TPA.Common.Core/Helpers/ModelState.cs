using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Helpers
{
    public static class ModelStateCustom
    {
        public static List<string> ErrorMessages = new List<string>();
        public static string ErrorMessageString = string.Empty;

        public static bool IsValid<T>(T model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, validationContext, results, true))
            {
                return true;
            }
            else
            {
                ErrorMessageString = string.Join(",", results.Select(x => x.ErrorMessage).ToList());
                ErrorMessages = results.Select(x => x.ErrorMessage).ToList();
                return false;
            }
        }
    }
}
