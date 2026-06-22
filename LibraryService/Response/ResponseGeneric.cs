using LibraryService.Response;

public class ResponseGeneric<T> : Response, IResponse<T>
{
    public T? Data { get; set; }

    public ResponseGeneric(T? data, bool isSuccess, string? message) : base(isSuccess, message)
    {
        Data = data;
    }

    public static ResponseGeneric<T> Success(T? data, string? message = "")
    {
        return new ResponseGeneric<T>(data, true, message);
    }

    public static new ResponseGeneric<T> Error(string? message = "")
    {
        return new ResponseGeneric<T>(default(T), false, message);
    }
}