namespace Nancy.Validation.DataAnnotations.Extensions.Tests
{
    using FakeItEasy;

    public abstract class BaseTestFixture<T> where T : IDataAnnotationsValidatorAdapter, new()
    {
        protected readonly IModelValidatorFactory _factory;

        public BaseTestFixture()
        {
            var adapterFactory = new DefaultPropertyValidatorFactory(new IDataAnnotationsValidatorAdapter[]
            {
                new T()
            });

            var validator = A.Fake<IValidatableObjectAdapter>();

            _factory = new DataAnnotationsValidatorFactory(adapterFactory, validator);
        }
    }
}