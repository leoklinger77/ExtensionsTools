using Klinger.ExtensionsTools.Tools;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Klinger.ExtensionsTools.DataAnnotationsExtensions
{
    public class IsCpfAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => ConfigDataAnnotationsExtension.MessageIsCpf;

        public IsCpfAttribute() { }
        public IsCpfAttribute(string errorMessage) : base(errorMessage)
        {
            ConfigDataAnnotationsExtension.MessageIsCpf = errorMessage;
        }       

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = value as string;

            if (!string.IsNullOrEmpty(cpf) && !cpf.IsCpf())
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }

    public class CpfAttributeAdapter : AttributeAdapterBase<IsCpfAttribute>
    {
        public CpfAttributeAdapter(IsCpfAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {

        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-cpf", GetErrorMessage(context));
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return ConfigDataAnnotationsExtension.MessageCpfFormat;
        }
    }

    public class CpfValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is IsCpfAttribute CpfAttribute)
            {
                return new CpfAttributeAdapter(CpfAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
