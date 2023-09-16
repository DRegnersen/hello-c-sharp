using Isu.Exceptions;

namespace Isu.Entities;

public class Student : IEquatable<Student>
{
    public Student(string studentName, int studentId, Group studentGroup)
    {
        if (string.IsNullOrEmpty(studentName))
        {
            throw StudentException.NameIsNullOrEmpty();
        }

        studentGroup.AddStudent(this);
        Group = studentGroup;
        Name = studentName;
        Id = studentId;
    }

    public string Name { get; }

    public int Id { get; }

    public Group Group { get; private set; }

    public void TransferToGroup(Group newGroup)
    {
        newGroup.AddStudent(this);
        Group.RemoveStudent(this);
        Group = newGroup;
    }

    public override string ToString()
    {
        return $"{Name} ({Id:d6})";
    }

    public bool Equals(Student? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}