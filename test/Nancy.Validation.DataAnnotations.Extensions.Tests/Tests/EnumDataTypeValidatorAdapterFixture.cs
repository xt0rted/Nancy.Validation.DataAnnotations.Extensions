namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Shouldly;

    using Xunit;

    public class EnumDataTypeValidatorAdapterFixture : BaseTestFixture<EnumDataTypeValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_value()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel
            {
                Status1 = Status.None,
                Status2 = Status.Pending,
                Status3 = Status.Approved
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_enum_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "EnumDataType" && r.MemberNames.Contains("Status1"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "EnumDataType" && r.MemberNames.Contains("Status2"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "EnumDataType" && r.MemberNames.Contains("Status3"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel { Status1 = (Status)13 };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["Status1"][0].ErrorMessage.ShouldBe("The field Status1 is invalid.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel { Status2 = (Status)13 };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["Status2"][0].ErrorMessage.ShouldBe("The field Status 2 is invalid.");
        }

        [Fact]
        public void Should_return_false_and_contain_displayname()
        {
            // Given
            var validator = _factory.Create(typeof(TestModel));
            var model = new TestModel { Status3 = (Status)13 };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["Status3"][0].ErrorMessage.ShouldBe("The field Status 3 is invalid.");
        }

        private class TestModel
        {
            [EnumDataType(typeof(Status))]
            public Status Status1 { get; set; }

            [Display(Name = "Status 2")]
            [EnumDataType(typeof(Status))]
            public Status Status2 { get; set; }

            [DisplayName("Status 3")]
            [EnumDataType(typeof(Status))]
            public Status Status3 { get; set; }
        }

        private enum Status
        {
            None = 0,
            Pending = 1,
            Approved = 2,
            Denied = 3
        }
    }
}
