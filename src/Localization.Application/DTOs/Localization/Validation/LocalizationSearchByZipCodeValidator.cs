namespace Localization.Application.DTOs.Localization.Validation;

public class LocalizationSearchByZipCodeValidator : LocalizationBaseValidator 
{
    public LocalizationSearchByZipCodeValidator()
        => this.ValidateZipCode();
}