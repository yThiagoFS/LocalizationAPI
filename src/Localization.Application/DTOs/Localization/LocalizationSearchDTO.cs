using MediatR;

namespace Localization.Application.DTOs.Localization;

public record LocalizationSearchDTO(string? State, string? IBGECode, string? City, int? Skip = 0, int? Take = 40) : IRequest<ResponseDTO<LocalizationResponseDTO>>;