namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class UrlValidatorAdapter : BaseValidatorAdapter<UrlAttribute>
    {
        public UrlValidatorAdapter()
            : base("Url")
        {
        }
    }
}