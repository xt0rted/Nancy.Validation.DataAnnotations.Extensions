namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Xunit;

    public class CompareValidatorAdapterFixture : BaseTestFixture<CompareValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_comparison()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Value1 = "1", Value1Confirmation = "1",
                Value2 = "2", Value2Confirmation = "2",
                Value3 = "3", Value3Confirmation = "3"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Should_read_compare_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Comparison" && r.MemberNames.Contains("Value1Confirmation"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Comparison" && r.MemberNames.Contains("Value2Confirmation"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Comparison" && r.MemberNames.Contains("Value3Confirmation"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Value1 = "1",
                Value1Confirmation = "2"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["Value1"][0].ErrorMessage.ShouldEqual("'Value1Confirmation' and 'Value1' do not match.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Value3 = "3",
                Value3Confirmation = "4"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["Value3Confirmation"][0].ErrorMessage.ShouldEqual("'Value 3 Confirmation' and 'Value 3' do not match.");
        }

        private class TestModel
        {
            public string Value1 { get; set; }

            [Compare("Value1")]
            public string Value1Confirmation { get; set; }

            public string Value2 { get; set; }

            [Compare("Value2")]
            public string Value2Confirmation { get; set; }

            [DisplayName("Value 3")]
            public string Value3 { get; set; }

            [DisplayName("Value 3 Confirmation")]
            [Compare("Value3")]
            public string Value3Confirmation { get; set; }
        }
    }
}