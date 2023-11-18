using FluentValidation.Results;
using Localization.Application.DTOs.Localization.Validation;
using MediatR;

namespace Localization.Application.DTOs.Localization;

public class LocalizationSearchByStateDTO : LocalizationBaseDTO
    , IRequest<ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
{
    public LocalizationSearchByStateDTO(string state) 
        => this.State = state;

    public List<ValidationFailure>? Validate() 
    {
        var validator = new LocalizationSearchByStateValidator().Validate(this);

        return validator.Errors;
    }
}