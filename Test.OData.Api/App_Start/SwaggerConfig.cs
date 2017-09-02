using System.Web.Http;
using WebActivatorEx;
using Test.OData.Api;
using Swashbuckle.Application;
using Swashbuckle.OData;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Test.OData.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Test.Api.Dummy");
                    c.PrettyPrint();
                    c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, GlobalConfiguration.Configuration).Configure(odataConfig =>
                    {
                        c.CustomProvider(df => new ODataSwaggerProvider(df, c, GlobalConfiguration.Configuration));
                    }));
                })
                .EnableSwaggerUi(c => { });
        }
    }
}