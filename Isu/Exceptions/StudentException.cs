namespace Isu.Exceptions;

public class StudentException : Exception
{
    private StudentException(string message)
        : base(message)
    {
    }

    public static StudentException NameIsNullOrEmpty()
    {
        return new StudentException("Given student name is null or empty");
    }
}