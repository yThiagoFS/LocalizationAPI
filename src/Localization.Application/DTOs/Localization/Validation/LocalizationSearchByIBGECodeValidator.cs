namespace Localization.Application.DTOs.Localization.Validation;

public class LocalizationSearchByIBGECodeValidator : LocalizationBaseValidator 
{
    public LocalizationSearchByIBGECodeValidator()
        => this.ValidateIBGECode();   
}