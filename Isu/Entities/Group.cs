using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities;

public class Group : IEquatable<Group>
{
    public const int MaxGroupBoard = 30;

    private readonly List<Student> _groupBoard;

    public Group(IGroupName groupName)
        : this(groupName, new List<Student>())
    {
    }

    public Group(IGroupName groupName, List<Student> groupBoard)
    {
        if (groupBoard.Count > MaxGroupBoard)
        {
            throw GroupException.IsOverflowed();
        }

        Name = groupName;
        _groupBoard = new List<Student>(groupBoard);
    }

    public IGroupName Name { get; }

    public IReadOnlyCollection<Student> Students => _groupBoard.AsReadOnly();

    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        if (_groupBoard.Contains(student))
        {
            throw GroupException.AlreadyContains();
        }

        if (_groupBoard.Count == MaxGroupBoard)
        {
            throw GroupException.IsOverflowed();
        }

        _groupBoard.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (!_groupBoard.Remove(student))
        {
            throw GroupException.DoesNotContain();
        }
    }

    public bool Equals(Group? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _groupBoard.Equals(other._groupBoard) && Name.Equals(other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Group)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_groupBoard, Name);
    }
}