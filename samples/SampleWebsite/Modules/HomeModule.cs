namespace SampleWebsite.Modules
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Nancy;
    using Nancy.ModelBinding;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return View["Index", new UserAccountModel
                {
                    AccountCreditCard = "4242424242424242",
                    HomePhone = "(123) 456-7890",
                    Website = "http://nancyfx.org",
                    PrimaryEmail = "test@nancyfx.org",
                    Resume = "MyResume.pdf",
                    Password = "password",
                    ConfirmPassword = "confirm password"
                }];
            };

            Post["/"] = _ =>
            {
                var model = this.BindAndValidate<UserAccountModel>();

                if (ModelValidationResult.IsValid)
                {
                    return View["Success"];
                }

                return View["Index", model];
            };
        }

        public class UserAccountModel
        {
            [CreditCard]
            [Display(Name = "Account Credit Card")]
            public string AccountCreditCard { get; set; }

            [Phone]
            [Display(Name = "Home Phone")]
            public string HomePhone { get; set; }

            [Url]
            [Display(Name = "Website Url")]
            public string Website { get; set; }

            [EmailAddress]
            [Display(Name = "Primary Email")]
            public string PrimaryEmail { get; set; }

            [FileExtensions(Extensions = "pdf,docx")]
            [Display(Name = "Allowed File Types")]
            public string Resume { get; set; }

            [Required]
            [MinLength(8), MaxLength(13)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Compare("Password")]
            [DisplayName("Confirm Password")]
            public string ConfirmPassword { get; set; }
        }
    }
}