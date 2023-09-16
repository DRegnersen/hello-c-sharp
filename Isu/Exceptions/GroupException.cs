namespace Isu.Exceptions;

public class GroupException : Exception
{
    private GroupException(string message)
        : base(message)
    {
    }

    public static GroupException IsOverflowed()
    {
        return new GroupException("Group is overflowed");
    }

    public static GroupException AlreadyContains()
    {
        return new GroupException("Group already contains given student");
    }

    public static GroupException DoesNotContain()
    {
        return new GroupException("Group does not contain given student");
    }
}