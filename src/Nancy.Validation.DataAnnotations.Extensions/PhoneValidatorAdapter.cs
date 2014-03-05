namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class PhoneValidatorAdapter : BaseValidatorAdapter<PhoneAttribute>
    {
        public PhoneValidatorAdapter()
            : base("Phone")
        {
        }
    }
}