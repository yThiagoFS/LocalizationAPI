using Localization.Application.DTOs;
using Localization.Application.DTOs.Localization;
using MediatR;

namespace Localization.Application.UseCases.Localization;

public class Handler : IRequestHandler<LocalizationSearchDTO, ResponseDTO<LocalizationResponseDTO>>
{
    public Task<ResponseDTO<LocalizationResponseDTO>> Handle(LocalizationSearchDTO request, CancellationToken cancellationToken)
    {
        throw new Exception("Got here");
    }
}