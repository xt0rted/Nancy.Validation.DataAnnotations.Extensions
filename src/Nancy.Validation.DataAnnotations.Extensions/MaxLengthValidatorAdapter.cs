namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class MaxLengthValidatorAdapter : BaseValidatorAdapter<MaxLengthAttribute>
    {
        public MaxLengthValidatorAdapter()
            : base("MaxLength")
        {
        }
    }
}