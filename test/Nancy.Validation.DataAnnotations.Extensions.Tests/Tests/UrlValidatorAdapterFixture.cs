namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Shouldly;

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
                BlogUrl = "http://blog.nancyfx.org",
                OtherUrl = "https://github.com/NancyFx/Nancy"
            };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Should_read_url_annotations()
        {
            // Given, When
            var validator = _factory.Create(typeof (TestModel));

            // Then
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Url" && r.MemberNames.Contains("WebPageUrl"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Url" && r.MemberNames.Contains("BlogUrl"));
            validator.Description.Rules.SelectMany(r => r.Value).ShouldContain(r => r.RuleType == "Url" && r.MemberNames.Contains("OtherUrl"));
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
            result.IsValid.ShouldBe(false);
            result.Errors["WebPageUrl"][0].ErrorMessage.ShouldBe("The WebPageUrl field is not a valid fully-qualified http, https, or ftp URL.");
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
            result.IsValid.ShouldBe(false);
            result.Errors["BlogUrl"][0].ErrorMessage.ShouldBe("The Blog Url field is not a valid fully-qualified http, https, or ftp URL.");
        }

        [Fact]
        public void Should_return_false_and_contain_displayname()
        {
            // Given
            var validator = _factory.Create(typeof (TestModel));
            var model = new TestModel { OtherUrl = "url" };

            // When
            var result = validator.Validate(model, new NancyContext());

            // Then
            result.IsValid.ShouldBe(false);
            result.Errors["OtherUrl"][0].ErrorMessage.ShouldBe("The Other Url field is not a valid fully-qualified http, https, or ftp URL.");
        }

        private class TestModel
        {
            [Url]
            public string WebPageUrl { get; set; }

            [Display(Name = "Blog Url")]
            [Url]
            public string BlogUrl { get; set; }

            [DisplayName("Other Url")]
            [Url]
            public string OtherUrl { get; set; }
        }
    }
}