using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private readonly List<Group> _isuGroups;
    private readonly IdGenerator _idGenerator;

    public IsuService()
    {
        _isuGroups = new List<Group>();
        _idGenerator = new IdGenerator();
    }

    public Group AddGroup(IGroupName name)
    {
        var group = new Group(name);
        if (!_isuGroups.Contains(group))
        {
            _isuGroups.Add(group);
        }

        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        if (!_isuGroups.Contains(group))
        {
            throw IsuServiceException.DoesNotContain();
        }

        var student = new Student(name, _idGenerator.GenerateId(), group);

        return student;
    }

    public Student GetStudent(int id)
    {
        return FindStudent(id) ?? throw IsuServiceException.NonExistentStudentId();
    }

    public Student? FindStudent(int id)
    {
        return _isuGroups.SelectMany(group => group.Students).FirstOrDefault(s => s.Id == id);
    }

    public List<Student> FindStudents(IGroupName groupName)
    {
        return FindGroup(groupName)?.Students.ToList() ?? new List<Student>();
    }

    public List<Student> FindStudents(ICourseNumber courseNumber)
    {
        return FindGroups(courseNumber).SelectMany(group => group.Students).ToList();
    }

    public Group? FindGroup(IGroupName groupName)
    {
        return _isuGroups.Find(group => group.Name.Equals(groupName));
    }

    public List<Group> FindGroups(ICourseNumber courseNumber)
    {
        return _isuGroups.Where(group => group.Name.CourseNumber.Equals(courseNumber)).ToList();
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        if (!_isuGroups.Contains(newGroup))
        {
            throw IsuServiceException.DoesNotContain();
        }

        Group? group = _isuGroups.Find(group => group.Students.FirstOrDefault(s => s.Equals(student)) != null);

        if (group is null)
        {
            throw IsuServiceException.NoGroupFound();
        }

        if (group.Equals(newGroup))
        {
            throw IsuServiceException.TransferringToSameGroup();
        }

        student.TransferToGroup(newGroup);
    }
}