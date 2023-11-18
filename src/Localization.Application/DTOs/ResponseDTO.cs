namespace Localization.Application.DTOs;

public class ResponseDTO<T>
{
    public ResponseDTO(T data)
    {
        this.Data = data;
    }

    public T Data { get; set; } = default!;
}