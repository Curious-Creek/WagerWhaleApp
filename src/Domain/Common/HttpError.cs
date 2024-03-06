namespace Domain.Common;

public class HttpError
{
    public string ErrorTitle { get; set; }
    public string[] ErrorMessages { get; set; }
}

public class HttpErrorWrapper
{
    public string Type;
    public string Title;
    public int Status;
    public HttpError[] Errors;
}