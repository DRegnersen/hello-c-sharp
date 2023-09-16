using Isu.Exceptions;

namespace Isu.Tools;

public class IdGenerator
{
    private const int MaxIdValue = 999999;
    private int _createdValue = 1;

    public int GenerateId()
    {
        if (_createdValue > MaxIdValue)
        {
            throw IdGeneratorException.IsOverflowed();
        }

        return _createdValue++;
    }
}