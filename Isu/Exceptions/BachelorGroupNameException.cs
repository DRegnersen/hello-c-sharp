namespace Isu.Exceptions;

public class BachelorGroupNameException : Exception
{
    private BachelorGroupNameException(string message)
        : base(message)
    {
    }

    public static BachelorGroupNameException InvalidNameLengthOrNull()
    {
        return new BachelorGroupNameException("Invalid group name length or it is null");
    }

    public static BachelorGroupNameException InvalidMajorFormat()
    {
        return new BachelorGroupNameException("Given major is invalid");
    }

    public static BachelorGroupNameException InvalidDegreeFormat()
    {
        return new BachelorGroupNameException("Given degree is invalid");
    }

    public static BachelorGroupNameException InvalidCourseNumberFormat()
    {
        return new BachelorGroupNameException("Given course number is invalid");
    }

    public static BachelorGroupNameException InvalidGroupNumberValue()
    {
        return new BachelorGroupNameException("Given group number is invalid");
    }
}