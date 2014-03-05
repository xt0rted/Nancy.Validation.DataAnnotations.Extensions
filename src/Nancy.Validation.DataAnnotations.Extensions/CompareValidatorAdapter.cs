namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Nancy.Validation.Rules;

    public class CompareValidatorAdapter : BaseValidatorAdapter<CompareAttribute>
    {
        public CompareValidatorAdapter()
            : base("Compare")
        {
        }

        public override IEnumerable<ModelValidationRule> GetRules(ValidationAttribute attribute, PropertyDescriptor descriptor)
        {
            var compareAttribute = (CompareAttribute)attribute;

            yield return new ComparisonValidationRule(attribute.FormatErrorMessage,
                                                      new[] { descriptor.Name },
                                                      ComparisonOperator.Equal,
                                                      compareAttribute.OtherProperty);
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
            var compareAttribute = (CompareAttribute)attribute;

            // member names are NOT returned from GetValidationResult like they are with other validation attributes
            return new ModelValidationError(new[]
            {
                context.MemberName,
                compareAttribute.OtherProperty
            }, result.ErrorMessage);
        }
    }
}