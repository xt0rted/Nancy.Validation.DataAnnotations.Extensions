namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Xunit;

    public class FileExtensionsValidatorAdapterFixture : BaseTestFixture<FileExtensionsValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_extensions()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                Avatar1 = "me.png",
                Avatar2 = "you.jpg"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Should_read_extension_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "FileExtension" && r.MemberNames.Contains("Avatar1"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "FileExtension" && r.MemberNames.Contains("Avatar2"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { Avatar1 = "me" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["Avatar1"][0].ErrorMessage.ShouldEqual("The Avatar1 field only accepts files with the following extensions: .png, .jpg, .jpeg, .gif");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { Avatar2 = "you" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["Avatar2"][0].ErrorMessage.ShouldEqual("The Avatar Url field only accepts files with the following extensions: .png, .jpg, .jpeg, .gif");
        }
    }
}