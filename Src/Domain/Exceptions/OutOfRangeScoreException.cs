using Shared.Exceptions;

namespace Domain.Exceptions;

public class OutOfRangeScoreException:PublicException
{
    public OutOfRangeScoreException(string score) 
        : base($"Score \"{score}\" Should between 0 to 50")
    {
    }
}