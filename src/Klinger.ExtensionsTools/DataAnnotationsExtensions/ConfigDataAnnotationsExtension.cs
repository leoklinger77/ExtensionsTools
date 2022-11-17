using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Klinger.ExtensionsTools.DataAnnotationsExtensions
{
    public static class ConfigDataAnnotationsExtension
    {
        public static string MessageIsCnpj = $"Cnpj inválido";
        public static string MessageIsCpf = $"Cpf inválido";

        public static string MessageCnpjFormat = $"Cnpj em formato inválido";
        public static string MessageCpfFormat = $"Cpf em formato inválido";

        public static string MessageIsUnderage = $"Idade inválida";
        public static string MessageUnderageFormat = $"Data em formato inválido";

        public static IServiceCollection ConfigAnnotationsExtensions(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CnpjValidationAttributeAdapterProvider>();
            services.AddSingleton<IValidationAttributeAdapterProvider, UnderageValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
