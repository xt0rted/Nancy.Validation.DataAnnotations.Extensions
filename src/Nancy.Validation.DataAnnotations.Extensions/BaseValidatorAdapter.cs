namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseValidatorAdapter<T> : DataAnnotationsValidatorAdapter where T : ValidationAttribute
    {
        public BaseValidatorAdapter(string ruleType)
            : base(ruleType)
        {
        }

        public override bool CanHandle(ValidationAttribute attribute)
        {
            return attribute is T;
        }

        public override IEnumerable<ModelValidationError> Validate(object instance, ValidationAttribute attribute, PropertyDescriptor descriptor, NancyContext context)
        {
            var validationContext = new ValidationContext(instance, null, null)
            {
                MemberName = descriptor == null ? null : descriptor.Name
            };

            if (descriptor != null)
            {
                // DisplayName() will auto populate the context, while Display(Name) needs to be manually set
                if (validationContext.MemberName == validationContext.DisplayName && !string.IsNullOrEmpty(descriptor.DisplayName))
                {
                    validationContext.DisplayName = descriptor.DisplayName;
                }

                instance = descriptor.GetValue(instance);
            }

            var result = attribute.GetValidationResult(instance, validationContext);

            if (result != null)
            {
                yield return GetValidationError(result, validationContext, attribute);
            }
        }

        private ModelValidationError GetValidationError(ValidationResult result, ValidationContext context, ValidationAttribute attribute)
        {
            return new ModelValidationError(result.MemberNames, result.ErrorMessage);
        }
    }
}