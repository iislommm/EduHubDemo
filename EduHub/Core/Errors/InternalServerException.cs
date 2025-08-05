using Core.Errors;

public class InternalServerException : BaseException
{
    public InternalServerException(string message = "Internal server error")
    {
    }
}
