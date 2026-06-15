namespace NumberToWords.Api.Exceptions;

public abstract class CustomException : Exception
{
    protected CustomException(string message) : base(message)
    {
        
    }
}

public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}