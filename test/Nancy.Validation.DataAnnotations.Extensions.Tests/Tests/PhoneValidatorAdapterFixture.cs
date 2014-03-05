namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Xunit;

    public class PhoneValidatorAdapterFixture : BaseTestFixture<PhoneValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_phone_number()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                HomePhoneNumber = "123-456-7890",
                WorkPhoneNumber = "456-123-7890"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Should_read_phone_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Phone" && r.MemberNames.Contains("HomePhoneNumber"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Phone" && r.MemberNames.Contains("WorkPhoneNumber"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { HomePhoneNumber = "home" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["HomePhoneNumber"][0].ErrorMessage.ShouldEqual("The HomePhoneNumber field is not a valid phone number.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { WorkPhoneNumber = "work" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["WorkPhoneNumber"][0].ErrorMessage.ShouldEqual("The Work Phone Number field is not a valid phone number.");
        }
    }
}