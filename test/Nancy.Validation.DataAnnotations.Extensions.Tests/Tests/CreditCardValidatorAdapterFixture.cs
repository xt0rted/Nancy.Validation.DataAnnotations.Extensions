namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
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
                MasterCard = "5555 5555 5555 4444",
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
            var validator = _factory.Create(typeof (TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "CreditCard" && r.MemberNames.Contains("MasterCard"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "CreditCard" && r.MemberNames.Contains("VisaCard"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "CreditCard" && r.MemberNames.Contains("DiscoverCard"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { MasterCard = "mastercard" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["MasterCard"][0].ErrorMessage.ShouldBe("The MasterCard field is not a valid credit card number.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { VisaCard = "visa" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["VisaCard"][0].ErrorMessage.ShouldBe("The Visa Card field is not a valid credit card number.");
        }

        [Fact]
        public void Should_return_false_and_contain_displayname()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { DiscoverCard = "discover" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["DiscoverCard"][0].ErrorMessage.ShouldBe("The Discover Card field is not a valid credit card number.");
        }

        private class TestModel
        {
            [CreditCard]
            public string MasterCard { get; set; }

            [Display(Name = "Visa Card")]
            [CreditCard]
            public string VisaCard { get; set; }

            [DisplayName("Discover Card")]
            [CreditCard]
            public string DiscoverCard { get; set; }
        }
    }
}