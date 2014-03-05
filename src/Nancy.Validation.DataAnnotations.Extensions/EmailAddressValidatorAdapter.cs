namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Nancy.Validation.Rules;

    public class EmailAddressValidatorAdapter : BaseValidatorAdapter<EmailAddressAttribute>
    {
        public EmailAddressValidatorAdapter()
            : base("Email")
        {
        }

        public override IEnumerable<ModelValidationRule> GetRules(ValidationAttribute attribute, PropertyDescriptor descriptor)
        {
            // this regex comes from the jquery validation project, which is what the regex in the EmailAddressAttribute is based on
            // more information on the regex can be found here http://www.whatwg.org/specs/web-apps/current-work/multipage/states-of-the-type-attribute.html#e-mail-state-%28type=email%29
            yield return new RegexValidationRule(attribute.FormatErrorMessage,
                                                 new[] { descriptor.Name },
                                                 @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
        }
    }
}