namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.Linq;

    using Xunit;

    public class UrlValidatorAdapterFixture : BaseTestFixture<UrlValidatorAdapter>
    {
        [Fact]
        public void Should_return_true_with_valid_urls()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel
            {
                WebPageUrl = "http://nancyfx.org",
                BlogUrl = "http://blog.nancyfx.org"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Should_read_url_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof(TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Url" && r.MemberNames.Contains("WebPageUrl"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldHave(r => r.RuleType == "Url" && r.MemberNames.Contains("BlogUrl"));
        }

        [Fact]
        public void Should_return_false_and_contain_property_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { WebPageUrl = "url" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["WebPageUrl"][0].ErrorMessage.ShouldEqual("The WebPageUrl field is not a valid fully-qualified http, https, or ftp URL.");
        }

        [Fact]
        public void Should_return_false_and_contain_display_name()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { BlogUrl = "url" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBeFalse();
            result.Errors["BlogUrl"][0].ErrorMessage.ShouldEqual("The Blog Url field is not a valid fully-qualified http, https, or ftp URL.");
        }
    }
}