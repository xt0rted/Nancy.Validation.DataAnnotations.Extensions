namespace SampleWebsite
{
    using Nancy.Conventions;

    public class Bootstrapper : Nancy.DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.AddDirectory("Scripts");
        }
    }
}