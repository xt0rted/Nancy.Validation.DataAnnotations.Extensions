namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public class FileExtensionsValidatorAdapter : BaseValidatorAdapter<FileExtensionsAttribute>
    {
        public FileExtensionsValidatorAdapter()
            : base("FileExtension")
        {
        }
    }
}