using FluentValidation.Results;
using Localization.Application.DTOs.Localization.Validation;
using MediatR;

namespace Localization.Application.DTOs.Localization;

public class LocalizationSearchByZipCodeDTO : LocalizationBaseDTO
    , IRequest<ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
{
    public LocalizationSearchByZipCodeDTO(string zipCode)
        => this.ZipCode = zipCode;

    public List<ValidationFailure>? Validate() 
    {
        var validator = new LocalizationSearchByZipCodeValidator().Validate(this);

        return validator.Errors;
    }
}