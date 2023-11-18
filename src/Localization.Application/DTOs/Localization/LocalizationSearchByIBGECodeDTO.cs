using FluentValidation.Results;
using Localization.Application.DTOs.Localization.Validation;
using MediatR;

namespace Localization.Application.DTOs.Localization;

public class LocalizationSearchByIBGECodeDTO : LocalizationBaseDTO
    , IRequest<ResponseDTO<LocalizationResponseDTO>>
{
    public LocalizationSearchByIBGECodeDTO(string ibgeCode)
        => this.IBGECode = ibgeCode;

    public List<ValidationFailure>? Validate() 
    {
        var validator = new LocalizationSearchByIBGECodeValidator().Validate(this);

        return validator.Errors;
    }
}