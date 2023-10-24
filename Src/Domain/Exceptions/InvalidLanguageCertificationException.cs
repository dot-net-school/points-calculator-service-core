using Shared.Exceptions;

namespace Domain.Exceptions;

public class InvalidLanguageCertificationException: PublicException
{
    public InvalidLanguageCertificationException() 
        : base("LanguageCertification cannot be null")
    {
    }
}