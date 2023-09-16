namespace Isu.Exceptions;

public class BachelorCourseNumberException : Exception
{
    private BachelorCourseNumberException(string message)
        : base(message)
    {
    }

    public static BachelorCourseNumberException InvalidCourseNumberValue()
    {
        return new BachelorCourseNumberException("Given course number is invalid");
    }
}