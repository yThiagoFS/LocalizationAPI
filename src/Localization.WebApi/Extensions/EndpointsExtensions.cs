using Localization.Application.DTOs.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Localization.WebApi.Extensions;

public static class EndpointsExtensions
{
    public static void MapLocalizationEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", () => Results.Ok("Hello World"));

        builder.MapGet("/localization", async ([FromServices] IMediator mediator, [FromBody] LocalizationSearchDTO request)   => 
        {
            var response = await mediator.Send(request);

            return Results.Ok(response);
        })
        .WithName("GetLocalization")
        .WithOpenApi(operation => new(operation) 
        {
            Summary = "Get localizations",
            Description = "Get localizations using one or more query options.",
        })
        .Accepts<LocalizationSearchDTO>("application/json");
    }
}