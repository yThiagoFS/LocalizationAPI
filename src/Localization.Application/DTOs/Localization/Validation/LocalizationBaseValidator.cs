using FluentValidation;

namespace Localization.Application.DTOs.Localization.Validation;

public abstract class LocalizationBaseValidator : AbstractValidator<LocalizationBaseDTO> 
{
    protected void ValidateState() 
    {
        RuleFor(l => l.State)
            .Length(2).WithMessage("Invalid state, use the acronym of the state.")
            .NotNull().WithMessage("State cannot be null or empty.")
            .NotEmpty().WithMessage("State cannot be null or empty.")
            .Matches("^[a-zA-Z]+$").WithMessage("Only letters are avaliable for the state.");
    }

    protected void ValidateIBGECode() 
    {
        RuleFor(l => l.IBGECode)
            .Length(8).WithMessage("Invalid IBGE code.")
            .NotNull().WithMessage("IBGE code cannot be null or empty.")
            .NotEmpty().WithMessage("IBGE code cannot be null or empty.")
            .Matches("^[0-9]*$").WithMessage("Invalid IBGE code, type only numbers.");
    }

    protected void ValidateZipCode() 
    {
        RuleFor(l => l.ZipCode)
            .Length(8).WithMessage("Invalid zip code.")
            .NotNull().WithMessage("Zip code cannot be null or empty.")
            .NotEmpty().WithMessage("Zip code cannot be null or empty.")
            .Matches("^[0-9]*$").WithMessage("Invalid zip code, type only numbers.");
    }
}