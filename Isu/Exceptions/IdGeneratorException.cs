namespace Isu.Exceptions;

public class IdGeneratorException : Exception
{
    private IdGeneratorException(string message)
        : base(message)
    {
    }

    public static IdGeneratorException IsOverflowed()
    {
        return new IdGeneratorException("Number of indexes in service has reached its maximum");
    }
}