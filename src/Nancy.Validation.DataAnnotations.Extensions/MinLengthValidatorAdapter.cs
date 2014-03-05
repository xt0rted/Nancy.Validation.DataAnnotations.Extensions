namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class MinLengthValidatorAdapter : BaseValidatorAdapter<MinLengthAttribute>
    {
        public MinLengthValidatorAdapter()
            : base("MinLength")
        {
        }
    }
}