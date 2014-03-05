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

        public override IEnumerable<ModelValidationError> Validate(object instance, ValidationAttribute attribute, PropertyDescriptor descriptor)
        {
            var context = new ValidationContext(instance, null, null)
            {
                MemberName = descriptor == null ? null : descriptor.Name
            };

            if (descriptor != null)
            {
                if (!string.IsNullOrEmpty(descriptor.DisplayName))
                {
                    context.DisplayName = descriptor.DisplayName;
                }

                instance = descriptor.GetValue(instance);
            }

            var result = attribute.GetValidationResult(instance, context);

            if (result != null)
            {
                yield return GetValidationError(result, context, attribute);
            }
        }

        private ModelValidationError GetValidationError(ValidationResult result, ValidationContext context, ValidationAttribute attribute)
        {
            return new ModelValidationError(result.MemberNames, result.ErrorMessage);
        }
    }
}