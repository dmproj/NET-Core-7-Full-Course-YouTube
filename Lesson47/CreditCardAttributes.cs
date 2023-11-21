using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.CustomValidators
{
    public class ChosenCreditCardAttribute : ValidationAttribute
    {
        private readonly string chosenCreditCard;

        public ChosenCreditCardAttribute(string chosenCreditCard)
        {
            this.chosenCreditCard = chosenCreditCard;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string creditCard && !string.Equals(creditCard, chosenCreditCard, StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Invalid credit card. Please use the chosen credit card for this offer.");
            }
            return ValidationResult.Success;
        }
    }

    public class LimitedCreditAmountAttribute : ValidationAttribute
    {
        private const decimal MaxCreditAmount = 1000;


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is decimal creditAmount && creditAmount > MaxCreditAmount)
            {
                return new ValidationResult($"Credit amount must be limited to ${MaxCreditAmount} for this offer");
            }
            return ValidationResult.Success;
        }
    }

    public class LimitedTimeOfferAttribute : ValidationAttribute
    {
        public DateTime ExpirationDate { get; set; }
        public string DefaultErrorMessage { get; set; } = "Transaction date should be before {0}";
        public string CreditCardUsedPropertyName { get; }
        public string CreditAmountPropertyName { get; }

        public LimitedTimeOfferAttribute(string creditCardUsedPropertyName, string creditAmountPropertyName, int offerDurationInMonths)
        {
            ExpirationDate = DateTime.Now.AddMonths(offerDurationInMonths);
            CreditCardUsedPropertyName = creditCardUsedPropertyName;
            CreditAmountPropertyName = creditAmountPropertyName;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime transactionDate)
            {
                var creditCardProperty = validationContext.ObjectType.GetProperty(CreditCardUsedPropertyName);
                var creditAmountProperty = validationContext.ObjectType.GetProperty(CreditAmountPropertyName);

                if (creditCardProperty != null && creditAmountProperty != null)
                {
                    var creditCardUsed = (string)creditCardProperty.GetValue(validationContext.ObjectInstance);
                    var creditAmount = (decimal)creditAmountProperty.GetValue(validationContext.ObjectInstance);

                    if (creditCardUsed == "MyPrefferedCard" && creditAmount > 0 && creditAmount <= 1000)
                    {

                        if (transactionDate > ExpirationDate)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, ExpirationDate));
                        }
                        return new ValidationResult("* Success *");
                    }
                }

                return new ValidationResult("Invalid data type or missing properties for CreditcardUsed and CreditAmount");
            }

            return new ValidationResult("Invalid data type for TransactionDate");
        }
    }
}