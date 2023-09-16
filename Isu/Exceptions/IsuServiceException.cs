namespace Isu.Exceptions;

public class IsuServiceException : Exception
{
    private IsuServiceException(string message)
        : base(message)
    {
    }

    public static IsuServiceException NoGroupFound()
    {
        return new IsuServiceException("Group was not found");
    }

    public static IsuServiceException TransferringToSameGroup()
    {
        return new IsuServiceException("Cannot transfer to the same group");
    }

    public static IsuServiceException DoesNotContain()
    {
        return new IsuServiceException("Service does not contain given group");
    }

    public static IsuServiceException NonExistentStudentId()
    {
        return new IsuServiceException("There is no such student id");
    }
}