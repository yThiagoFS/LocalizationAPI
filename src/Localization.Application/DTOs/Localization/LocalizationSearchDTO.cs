using FluentValidation.Results;
using Localization.Application.DTOs.Localization.Validation;
using MediatR;

namespace Localization.Application.DTOs.Localization;

public class LocalizationSearchDTO : LocalizationBaseDTO, IRequest<ResponseDTO<IEnumerable<LocalizationResponseDTO>>>
{
    public LocalizationSearchDTO(string? state, string? city, string? ibgeCode, string? zipCode)
    {
        this.State = state;
        this.City = city;
        this.IBGECode = ibgeCode;
        this.ZipCode = zipCode;
    }

    public List<ValidationFailure?> Validate() 
    {
        if(IsInvalidRequest)
        {
            return new List<ValidationFailure>() 
            {
                new ValidationFailure("Invalid Request", "At least 1 property should be valid to search for the data.")
            }!;
        }

        var validator = new LocalizationSearchValidator(this).Validate(this);

        return validator.Errors;
    }

    private bool IsInvalidRequest 
        => string.IsNullOrEmpty(this.State)
        && string.IsNullOrEmpty(this.City)
        && string.IsNullOrEmpty(this.IBGECode)
        && string.IsNullOrEmpty(this.ZipCode);
}