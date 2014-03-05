namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
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
                Value1 = "1",
                Value1Confirmation = "1",
                Value2 = "2",
                Value2Confirmation = "2"
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
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Comparison" && r.MemberNames.Contains("Value1"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Comparison" && r.MemberNames.Contains("Value2"));
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
            result.Errors["Value1"][0].ErrorMessage.ShouldEqual("'Value1' and 'Value1Confirmation' do not match.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Value2 = "1",
                Value2Confirmation = "2"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["Value2"][0].ErrorMessage.ShouldEqual("'Value 2' and 'Value 2 Confirmation' do not match.");
        }
    }
}