using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(IGroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student? FindStudent(int id);
    List<Student> FindStudents(IGroupName groupName);
    List<Student> FindStudents(ICourseNumber courseNumber);

    Group? FindGroup(IGroupName groupName);
    List<Group> FindGroups(ICourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}