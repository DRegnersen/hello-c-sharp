namespace Isu.Models;

public interface IGroupName
{
    char Major { get; }

    ICourseNumber CourseNumber { get; }

    int Number { get; }
}