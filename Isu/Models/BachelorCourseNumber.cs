using Isu.Exceptions;

namespace Isu.Models;

public class BachelorCourseNumber : ICourseNumber, IEquatable<BachelorCourseNumber>
{
    private const int MinCourseNumber = 1;
    private const int MaxCourseNumber = 4;

    public BachelorCourseNumber(int courseNumberValue)
    {
        if (courseNumberValue is < MinCourseNumber or > MaxCourseNumber)
        {
            throw BachelorCourseNumberException.InvalidCourseNumberValue();
        }

        CourseNumberValue = courseNumberValue;
    }

    public int CourseNumberValue { get; }

    public bool Equals(BachelorCourseNumber? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CourseNumberValue == other.CourseNumberValue;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BachelorCourseNumber)obj);
    }

    public override int GetHashCode()
    {
        return CourseNumberValue;
    }

    public override string ToString()
    {
        return $"{CourseNumberValue}";
    }
}