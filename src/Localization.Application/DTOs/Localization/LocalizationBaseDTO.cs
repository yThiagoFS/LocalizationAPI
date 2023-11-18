using FluentValidation.Results;

namespace Localization.Application.DTOs.Localization;

public class LocalizationBaseDTO 
{
    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string IBGECode { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;
}