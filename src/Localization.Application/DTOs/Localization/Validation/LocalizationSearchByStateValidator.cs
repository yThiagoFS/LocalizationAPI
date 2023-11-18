namespace Localization.Application.DTOs.Localization.Validation;

public class LocalizationSearchByStateValidator : LocalizationBaseValidator 
{
    public LocalizationSearchByStateValidator()
        => this.ValidateState();
}