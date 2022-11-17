using Klinger.ExtensionsTools.Tools;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Klinger.ExtensionsTools.DataAnnotationsExtensions
{
    public class IsCnpjAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => ConfigDataAnnotationsExtension.MessageIsCnpj;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cnpj = value as string;

            if (!string.IsNullOrEmpty(cnpj) && !cnpj.IsCnpj())
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }        
    }    

    public class CnpjAttributeAdapter : AttributeAdapterBase<IsCnpjAttribute>
    {
        public CnpjAttributeAdapter(IsCnpjAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-cnpj", GetErrorMessage(context));
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return ConfigDataAnnotationsExtension.MessageCpfFormat;
        }
    }

    public class CnpjValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is IsCnpjAttribute CpfAttribute)
            {
                return new CnpjAttributeAdapter(CpfAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
