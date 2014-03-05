namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TestModel
    {
        [EmailAddress]
        public string PersonalEmail { get; set; }

        [DisplayName("Work Email Address")]
        [EmailAddress]
        public string WorkEmail { get; set; }

        [Phone]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Work Phone Number")]
        [Phone]
        public string WorkPhoneNumber { get; set; }

        [CreditCard]
        public string VisaCard { get; set; }
        
        [DisplayName("Discover Card")]
        [CreditCard]
        public string DiscoverCard { get; set; }

        [MinLength(2)]
        [MaxLength(3)]
        public string Password { get; set; }

        [DisplayName("Password Confirmation")]
        [MinLength(2)]
        [MaxLength(3)]
        public string PasswordConfirmation { get; set; }

        [Compare("Value1Confirmation")]
        public string Value1 { get; set; }
        public string Value1Confirmation { get; set; }

        [DisplayName("Value 2")]
        [Compare("Value2Confirmation")]
        public string Value2 { get; set; }

        [DisplayName("Value 2 Confirmation")]
        public string Value2Confirmation { get; set; }

        [Url]
        public string WebPageUrl { get; set; }
        
        [DisplayName("Blog Url")]
        [Url]
        public string BlogUrl { get; set; }

        [FileExtensions]
        public string FileType1 { get; set; }

        [FileExtensions]
        public string Avatar1 { get; set; }
        
        [DisplayName("Avatar Url")]
        [FileExtensions]
        public string Avatar2 { get; set; }
    }
}