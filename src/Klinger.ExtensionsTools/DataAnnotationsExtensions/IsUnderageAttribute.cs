using Klinger.ExtensionsTools.Tools;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Klinger.ExtensionsTools.DataAnnotationsExtensions
{
    public class IsUnderageAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => ConfigDataAnnotationsExtension.MessageIsUnderage;
        public int Age { get; private set; }
        public IsUnderageAttribute(int age)
        {
            Age = age;
        }
        public IsUnderageAttribute(string errorMessage) : base(errorMessage)
        {

            ConfigDataAnnotationsExtension.MessageIsUnderage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                if (date.DateLessThanYear(Age)) return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }

    public class UnderageAttributeAdapter : AttributeAdapterBase<IsUnderageAttribute>
    {
        public UnderageAttributeAdapter(IsUnderageAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {

        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-underage", GetErrorMessage(context));
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return ConfigDataAnnotationsExtension.MessageUnderageFormat;
        }
    }

    public class UnderageValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is IsUnderageAttribute underageAttribute)
            {
                return new UnderageAttributeAdapter(underageAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
