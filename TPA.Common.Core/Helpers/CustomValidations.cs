using System.ComponentModel.DataAnnotations;

namespace TPA.Common.Core.Helpers
{
    //public class ValidLastDeliveryDate : ValidationAttribute
    //{
    //    //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    //{
    //    //    var model = (Models.Customer)validationContext.ObjectInstance;
    //    //    DateTime _lastDeliveryDate = Convert.ToDateTime(value);
    //    //    DateTime _dateJoin = Convert.ToDateTime(model.JoinDate);

    //    //    if (_dateJoin > _lastDeliveryDate)
    //    //    {
    //    //        return new ValidationResult
    //    //            ("Last Delivery Date can not be less than Join date.");
    //    //    }
    //    //    else if (_lastDeliveryDate > DateTime.Now)
    //    //    {
    //    //        return new ValidationResult
    //    //            ("Last Delivery Date can not be greater than current date.");
    //    //    }
    //    //    else
    //    //    {
    //    //        return ValidationResult.Success;
    //    //    }
    //    //}
    //}

    public class RequiredCustom : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(validationContext.DisplayName + Resources.Common.ResourceManager.GetString("IsRequired"));
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
