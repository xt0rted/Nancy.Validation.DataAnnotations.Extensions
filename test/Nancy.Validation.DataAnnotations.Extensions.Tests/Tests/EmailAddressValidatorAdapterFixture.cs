namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Shouldly;

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
                ThrowawayEmail = "junkemail@test.com",
                WorkEmail = "email2@test.com"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_email_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof (TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Regex" && r.MemberNames.Contains("PersonalEmail"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Regex" && r.MemberNames.Contains("ThrowawayEmail"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Regex" && r.MemberNames.Contains("WorkEmail"));
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
            result.IsValid.ShouldBe(false);
            result.Errors["PersonalEmail"][0].ErrorMessage.ShouldBe("The PersonalEmail field is not a valid e-mail address.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { ThrowawayEmail = "email" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["ThrowawayEmail"][0].ErrorMessage.ShouldBe("The Throwaway Email field is not a valid e-mail address.");
        }

        [Fact]
        public void Should_return_false_and_contain_displayname()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { WorkEmail = "email" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["WorkEmail"][0].ErrorMessage.ShouldBe("The Work Email Address field is not a valid e-mail address.");
        }

        private class TestModel
        {
            [EmailAddress]
            public string PersonalEmail { get; set; }

            [Display(Name = "Throwaway Email")]
            [EmailAddress]
            public string ThrowawayEmail { get; set; }

            [DisplayName("Work Email Address")]
            [EmailAddress]
            public string WorkEmail { get; set; }
        }
    }
}