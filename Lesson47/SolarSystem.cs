using hikitocAPI.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain
{
    public class SolarSystem
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)] //nvarchar(30)
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} can not be blank")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} needs to be me min {2} and max {1} chars.")]
        public string Name { get; set; }

        [Range(9.9, 99.99, ErrorMessage = "{0} needs to be me min {1} and max {2} km.")]
        [Display(Name = "Diameter in km")]
        public double DiameterKm { get; set; }

        [EmailAddress(ErrorMessage = "{0} format is invalid")]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} can not be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0}, it can not be blank")]
        [Compare("Password", ErrorMessage = "{1} and {0} do not match")]
        [Display(Name = "Confirm the password")]
        public string ConfirmPassword { get; set; }

        [Phone(ErrorMessage = "{0} should inlcude 10 digits. Only numeric values are allowed.")]
        public int? Phone { get; set; }

        [StringLength(1000)]
        [RegularExpression(@"\.(jpg|png)$", ErrorMessage = "{0} needs to be a .jpg or .png file")]
        public string? Image { get; set; }

        [ValidateNever]
        public string? IsActive { get; set; }

        //-----CUSTOM VALIDATION PROPERTIES-------

        [ChosenCreditCard("MyPrefferedCard")]
        public string CreditCardUsed { get; set; }

        [LimitedCreditAmount]
        public decimal CreditAmount { get; set; }

        [LimitedTimeOffer("CreditCardUsed", "CreditAmount", 1, ErrorMessage = "This limited-time offer has expired")]
        //[LimitedTimeOffer(1)]
        public DateTime TransactionDate { get; set; }
    }
}