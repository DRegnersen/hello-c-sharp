using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Tests;

public class IsuServiceTests
{
    private const string StandardStudentName = "Sergey Abobyan";
    private readonly IsuService _isuService = new();
    private readonly BachelorGroupName _standardGroupName = new("M3103");

    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var group = _isuService.AddGroup(_standardGroupName);
        var student = _isuService.AddStudent(group, StandardStudentName);

        // Result of adding checking
        Assert.NotNull(_isuService.FindStudent(student.Id));
        Assert.Contains(student, group.Students);
        Assert.True(student.Group.Name.Equals(_standardGroupName));
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var group = _isuService.AddGroup(_standardGroupName);

        for (var i = 1; i <= Group.MaxGroupBoard; i++)
        {
            _isuService.AddStudent(group, $"Sergey {i} Abobyan");
        }

        // Overflow
        Assert.Throws<GroupException>(() =>
        {
            _isuService.AddStudent(group, $"Sergey {Group.MaxGroupBoard + 1} Abobyan");
        });
    }

    [Theory]
    [InlineData("M21102003")]
    [InlineData("73107")]
    [InlineData("M3116")]
    public void CreateGroupWithInvalidName_ThrowException(string value)
    {
        // Invalid Group Data: Case 1
        Assert.Throws<BachelorGroupNameException>(() =>
        {
            var groupName = new BachelorGroupName(value);
        });
    }

    [Fact]
    public void CreateGroupWithInvalidCourse_ThrowException()
    {
        // Invalid Group Data: Case 2
        Assert.Throws<BachelorCourseNumberException>(() =>
        {
            var groupName = new BachelorGroupName("M3503");
        });
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var initialGroup = _isuService.AddGroup(_standardGroupName);

        var newGroupName = new BachelorGroupName("M3200");
        var newGroup = _isuService.AddGroup(newGroupName);

        var student = _isuService.AddStudent(initialGroup, StandardStudentName);
        _isuService.ChangeStudentGroup(student, newGroup);

        // Result of transferring checking
        Assert.NotNull(_isuService.FindStudent(student.Id));
        Assert.DoesNotContain(student, initialGroup.Students);
        Assert.Contains(student, newGroup.Students);
        Assert.True(student.Group.Name.Equals(newGroupName));
    }
}