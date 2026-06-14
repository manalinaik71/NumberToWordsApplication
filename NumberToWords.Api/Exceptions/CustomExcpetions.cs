using System.Net;

namespace NumberToWords.Api.Exceptions;

public abstract class CustomExceptions : Exception
{
    public CustomExceptions(string message) : base(message)
    {
        
    }
}

public class BadRequestException : CustomExceptions
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}