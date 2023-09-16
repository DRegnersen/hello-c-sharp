using System.Globalization;
using Isu.Exceptions;

namespace Isu.Models;

public class BachelorGroupName : IGroupName, IEquatable<BachelorGroupName>
{
    private const int GroupNameLength = 5;
    private const int MinGroupNumber = 0;
    private const int MaxGroupNumber = 15;
    private const int GroupDegree = 3;
    private const int MajorIndex = 0;
    private const int DegreeIndex = 1;
    private const int CourseIndex = 2;
    private const int GroupNumberStartIndex = 3;
    private const int GroupNumberLength = 2;

    public BachelorGroupName(string groupName)
    {
        ValidateName(groupName);

        Major = groupName[MajorIndex];
        CourseNumber = new BachelorCourseNumber(CharUnicodeInfo.GetDigitValue(groupName[CourseIndex]));
        Number = int.Parse(groupName.Substring(GroupNumberStartIndex, GroupNumberLength));
        Name = groupName;
    }

    public char Major { get; }

    public ICourseNumber CourseNumber { get; }

    public int Number { get; }

    private string Name { get; }

    public bool Equals(BachelorGroupName? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BachelorGroupName)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length != GroupNameLength)
        {
            throw BachelorGroupNameException.InvalidNameLengthOrNull();
        }

        if (!char.IsLetter(name[MajorIndex]) || !char.IsUpper(name[MajorIndex]))
        {
            throw BachelorGroupNameException.InvalidMajorFormat();
        }

        if (!char.IsDigit(name[DegreeIndex]) || CharUnicodeInfo.GetDigitValue(name[DegreeIndex]) != GroupDegree)
        {
            throw BachelorGroupNameException.InvalidDegreeFormat();
        }

        if (!char.IsDigit(name[CourseIndex]))
        {
            BachelorGroupNameException.InvalidCourseNumberFormat();
        }

        if (int.Parse(name.Substring(GroupNumberStartIndex, GroupNumberLength)) is < MinGroupNumber or > MaxGroupNumber)
        {
            throw BachelorGroupNameException.InvalidGroupNumberValue();
        }
    }
}