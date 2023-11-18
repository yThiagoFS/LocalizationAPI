using Localization.Application.DTOs.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Localization.WebApi.Extensions;

public static class EndpointsExtensions
{
    public static void MapLocalizationEndpoints(this IEndpointRouteBuilder builder)
    {
        BuildLocalizationQueryEndpoints(builder);
    }

    private static void BuildLocalizationQueryEndpoints(IEndpointRouteBuilder builder) 
    {
        builder.MapGet("/localization", async ([FromServices] IMediator mediator, [FromBody] LocalizationSearchDTO request) => 
        {
            var response = await mediator.Send(request);

            return Results.Ok(response);
        })
        .WithName("GetLocalization")
        .WithOpenApi(operation => new(operation) 
        {
            Summary = "Get localizations",
            Description = "Get localizations using one or more query options.",
        });

        builder.MapGet("/localization/getByState", async ([FromServices] IMediator mediator, [FromQuery(Name = "state")] string state) => 
        {
            var response = await mediator.Send(new LocalizationSearchByStateDTO(state));

            return Results.Ok(response);
        })
        .WithName("GetLocalizationByState")
        .WithOpenApi(operation => new(operation) 
        {
            Summary = "Get localizations by state,",
            Description = "Get localizations by state.",
        });

        builder.MapGet("/localization/getByZipCode", async ([FromServices] IMediator mediator, [FromQuery(Name = "zipCode")] string zipCode) => 
        {
            var response = await mediator.Send(new LocalizationSearchByZipCodeDTO(zipCode));

            return Results.Ok(response);
        })
        .WithName("GetLocalizationByZipCode")
        .WithOpenApi(operation => new(operation) 
        {
            Summary = "Get localizations by zip code,",
            Description = "Get localizations by zip code.",
        });

        builder.MapGet("/localization/getByIbgeCode", async ([FromServices] IMediator mediator, [FromQuery(Name = "ibgeCode")] string ibgeCode) => 
        {
            var response = await mediator.Send(new LocalizationSearchByIBGECodeDTO(ibgeCode));

            return Results.Ok(response);
        })
        .WithName("GetLocalizationByIBGECode")
        .WithOpenApi(operation => new(operation) 
        {
            Summary = "Get localizations by IBGE code,",
            Description = "Get localizations by IBGE code.",
        });
    }
}