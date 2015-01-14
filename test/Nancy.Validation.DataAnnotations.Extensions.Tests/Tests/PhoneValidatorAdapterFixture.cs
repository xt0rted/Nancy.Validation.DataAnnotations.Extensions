namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Shouldly;

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
                HomePhone = "123-456-7890",
                CellPhone = "231-456-7890",
                WorkPhone = "312-456-7890"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_phone_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof (TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Phone" && r.MemberNames.Contains("HomePhone"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Phone" && r.MemberNames.Contains("CellPhone"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Phone" && r.MemberNames.Contains("WorkPhone"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { HomePhone = "home" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["HomePhone"][0].ErrorMessage.ShouldBe("The HomePhone field is not a valid phone number.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { CellPhone = "cell" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["CellPhone"][0].ErrorMessage.ShouldBe("The Cell Phone field is not a valid phone number.");
        }

        [Fact]
        public void Should_return_false_and_contain_displayname()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { WorkPhone = "work" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["WorkPhone"][0].ErrorMessage.ShouldBe("The Work Phone field is not a valid phone number.");
        }

        private class TestModel
        {
            [Phone]
            public string HomePhone { get; set; }

            [Display(Name = "Cell Phone")]
            [Phone]
            public string CellPhone { get; set; }

            [DisplayName("Work Phone")]
            [Phone]
            public string WorkPhone { get; set; }
        }
    }
}