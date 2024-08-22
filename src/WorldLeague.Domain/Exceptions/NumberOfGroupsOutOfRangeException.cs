namespace WorldLeague.Domain.Exceptions;

public class NumberOfGroupsOutOfRangeException : BusinessException
{
    public NumberOfGroupsOutOfRangeException() : base("Number of groups must be 4 or 8")
    {

    }
}
