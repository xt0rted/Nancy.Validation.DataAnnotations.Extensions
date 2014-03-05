namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class CreditCardValidatorAdapter : BaseValidatorAdapter<CreditCardAttribute>
    {
        public CreditCardValidatorAdapter()
            : base("CreditCard")
        {
        }
    }
}