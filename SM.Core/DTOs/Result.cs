namespace SM.Core.DTOs;

public class Result<T>
{
    public T? Data { get; set; }

    public bool Success { get; set; } = false;

    public int Code { get; set; } = 500;

    public string? Message { get; set; }
}