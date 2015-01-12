namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Shouldly;

    using Xunit;

    public class CreditCardValidatorAdapterFixture : BaseTestFixture<CreditCardValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_card_numbers()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                VisaCard = "4242-4242-4242-4242",
                DiscoverCard = "6011-1111-1111-1117"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_creditcard_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "CreditCard" && r.MemberNames.Contains("VisaCard"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "CreditCard" && r.MemberNames.Contains("DiscoverCard"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel { VisaCard = "visa" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["VisaCard"][0].ErrorMessage.ShouldBe("The VisaCard field is not a valid credit card number.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel { DiscoverCard = "discover" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["DiscoverCard"][0].ErrorMessage.ShouldBe("The Discover Card field is not a valid credit card number.");
        }
    }
}