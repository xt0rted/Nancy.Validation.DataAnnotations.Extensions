namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Shouldly;

    using Xunit;

    public class MaxLengthValidatorAdapterFixture : BaseTestFixture<MaxLengthValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_lengths()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Password = "12",
                PasswordConfirmation = "123"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_maxlength_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "MaxLength" && r.MemberNames.Contains("Password"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "MaxLength" && r.MemberNames.Contains("PasswordConfirmation"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { Password = "1234" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["Password"][0].ErrorMessage.ShouldBe("The field Password must be a string or array type with a maximum length of '3'.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { PasswordConfirmation = "1234" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["PasswordConfirmation"][0].ErrorMessage.ShouldBe("The field Password Confirmation must be a string or array type with a maximum length of '3'.");
        }
    }
}