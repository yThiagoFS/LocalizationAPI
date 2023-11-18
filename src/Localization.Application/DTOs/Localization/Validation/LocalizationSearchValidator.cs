namespace Localization.Application.DTOs.Localization.Validation;

public class LocalizationSearchValidator : LocalizationBaseValidator 
{

    public LocalizationSearchValidator(LocalizationSearchDTO dto) 
        => ValidateFields(dto);

    public void ValidateFields(LocalizationSearchDTO dto) 
    {
        if(!string.IsNullOrEmpty(dto.State))
            this.ValidateState();

        if(!string.IsNullOrEmpty(dto.IBGECode))
            this.ValidateIBGECode();
            
        if(!string.IsNullOrEmpty(dto.ZipCode))
            this.ValidateZipCode();
    }
}