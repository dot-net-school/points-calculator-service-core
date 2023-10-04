namespace Shared.Exceptions;

public abstract class PublicException:Exception
{
    protected PublicException(string message):base(message)
    {
        
    }
}