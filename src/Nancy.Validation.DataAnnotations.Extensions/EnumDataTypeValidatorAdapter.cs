namespace Nancy.Validation.DataAnnotations.Extensions
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An adapter for the <see cref="EnumDataTypeAttribute"/>.
    /// </summary>
    public class EnumDataTypeValidatorAdapter : BaseValidatorAdapter<EnumDataTypeAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumDataTypeValidatorAdapter"/> class.
        /// </summary>
        public EnumDataTypeValidatorAdapter()
            : base("EnumDataType")
        {
        }
    }
}
