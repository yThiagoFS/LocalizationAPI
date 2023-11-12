namespace Localization.WebApi.Extensions;

public static class EndpointsExtensions
{
    public static void MapLocalizationEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/localization", async (HttpContext context)  => 
        {
            
        });
    }
}