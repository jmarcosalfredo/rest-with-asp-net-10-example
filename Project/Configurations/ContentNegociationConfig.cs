using Microsoft.Net.Http.Headers;

namespace rest_with_asp_net_10_example.Configurations;

public static class ContentNegociationConfig 
{
    public static IMvcBuilder AddContentNegociation(this IMvcBuilder mvcBuilder)
    {
        return mvcBuilder.AddMvcOptions(options =>
        {
        options.RespectBrowserAcceptHeader = true;
        options.ReturnHttpNotAcceptable = true;

        options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
        options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
        })
        .AddXmlSerializerFormatters();
    }
}