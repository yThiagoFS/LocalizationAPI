using System.Linq.Expressions;
using Localization.Application.DTOs;
using Localization.Application.DTOs.Localization;
using Localization.Domain.Repositories;
using MediatR;

namespace Localization.Application.UseCases.Localization.Get;

public class Handler : 
    IRequestHandler<LocalizationSearchDTO, ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
    , IRequestHandler<LocalizationSearchByStateDTO, ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
    , IRequestHandler<LocalizationSearchByIBGECodeDTO, ResponseDTO<LocalizationResponseDTO>>
    , IRequestHandler<LocalizationSearchByZipCodeDTO, ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
{
    private readonly ILocalizationRepository _localizationRepository;

    public Handler(ILocalizationRepository localizationRepository)
    {
        this._localizationRepository = localizationRepository;
    }

    public async Task<ResponseDTO<IEnumerable<LocalizationResponseDTO>>> Handle(LocalizationSearchDTO request, CancellationToken cancellationToken)
    {
        var validation = request.Validate();

        if(validation is not null && validation.Any()) 
            foreach(var error in validation) Console.WriteLine(error);

        var expressions = this.GetExpressions(request);

        var localizations = await this._localizationRepository.GetAndFilterBy(expressions);

        return new ResponseDTO<IEnumerable<LocalizationResponseDTO>>(localizations.Select(x => new LocalizationResponseDTO(x.AddedBy, x.CreatedAt, x.UpdatedBy, x.UpdatedAt, x.IBGECode.Code, x.State.Acronym, x.ZipCode.Code)));
    }

    public async Task<ResponseDTO<IEnumerable<LocalizationResponseDTO>>> Handle(LocalizationSearchByStateDTO request, CancellationToken cancellationToken)
    {
        var localizations = await this._localizationRepository.GetByState(request.State);

        return new ResponseDTO<IEnumerable<LocalizationResponseDTO>>(localizations.Select(x => new LocalizationResponseDTO(x.AddedBy, x.CreatedAt, x.UpdatedBy, x.UpdatedAt, x.IBGECode.Code, x.State.Acronym, x.ZipCode.Code)));
    }

    public async Task<ResponseDTO<LocalizationResponseDTO>> Handle(LocalizationSearchByIBGECodeDTO request, CancellationToken cancellationToken)
    {
        var localization = await this._localizationRepository.GetByIBGECode(request.IBGECode);

        return new ResponseDTO<LocalizationResponseDTO>(new LocalizationResponseDTO(localization.AddedBy, localization.CreatedAt, localization.UpdatedBy, localization.UpdatedAt, localization.IBGECode.Code, localization.State.Acronym, localization.ZipCode.Code));
    }

    public async Task<ResponseDTO<IEnumerable<LocalizationResponseDTO>>> Handle(LocalizationSearchByZipCodeDTO request, CancellationToken cancellationToken)
    {
         var localizations = await this._localizationRepository.GetByZipCode(request.ZipCode);

        return new ResponseDTO<IEnumerable<LocalizationResponseDTO>>(localizations.Select(x => new LocalizationResponseDTO(x.AddedBy, x.CreatedAt, x.UpdatedBy, x.UpdatedAt, x.IBGECode.Code, x.State.Acronym, x.ZipCode.Code)));
    }

    private List<Expression<Func<Domain.Entities.Localization, bool>>> GetExpressions(LocalizationSearchDTO request)
    {
        List<Expression<Func<Domain.Entities.Localization, bool>>> expressions = new();

        if(!string.IsNullOrEmpty(request.State))
            expressions.Add(l => l.State.Acronym.ToLower() == request.State.ToLower());

        if(!string.IsNullOrEmpty(request.IBGECode))
            expressions.Add(l => l.IBGECode.Code == request.IBGECode);
            
        if(!string.IsNullOrEmpty(request.ZipCode))
            expressions.Add(l => l.ZipCode.Code == request.ZipCode);

        return expressions;
    }
}