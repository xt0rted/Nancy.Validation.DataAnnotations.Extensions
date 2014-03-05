namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Xunit;

    public class EmailAddressValidatorAdapterFixture : BaseTestFixture<EmailAddressValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_email()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                PersonalEmail = "email1@test.com",
                WorkEmail = "email2@test.com"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Should_read_email_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Regex" && r.MemberNames.Contains("PersonalEmail"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Regex" && r.MemberNames.Contains("WorkEmail"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { PersonalEmail = "email" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["PersonalEmail"][0].ErrorMessage.ShouldEqual("The PersonalEmail field is not a valid e-mail address.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { WorkEmail = "email" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["WorkEmail"][0].ErrorMessage.ShouldEqual("The Work Email Address field is not a valid e-mail address.");
        }
    }
}