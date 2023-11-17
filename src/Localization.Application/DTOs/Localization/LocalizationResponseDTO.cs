using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Localization.Application.DTOs.Localization;

public record LocalizationResponseDTO ([Required] string AddedBy
    , [Required] DateTime CreatedAt
    , [AllowNull] string? UpdatedBy
    , [AllowNull] DateTime? UpdatedAt
    , [Required] string IBGECode
    , [Required] string State
    , [Required] string ZipCode);