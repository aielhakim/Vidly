using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // return base.IsValid(value, validationContext);

            Customer Customer = validationContext.ObjectInstance as Customer;
            if (Customer.MembershipTypeId == Models.MembershipType.Unknown || Customer.MembershipTypeId == Models.MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (Customer.BirthDate == null)
            {
                return new ValidationResult("BD is required");
            }

            var age = DateTime.Today.Year - Customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer must be +18");

        }
    }
}