using Pure.Primitives.Abstractions.DateTime;

namespace Pure.Primitives.DateTime.Operations;

internal sealed record DateTimeComparer : IComparer<IDateTime>
{
    public int Compare(IDateTime? first, IDateTime? second)
    {
        int result = first!.Year.NumberValue.CompareTo(second!.Year.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Month.NumberValue.CompareTo(second.Month.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Day.NumberValue.CompareTo(second.Day.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Hour.NumberValue.CompareTo(second.Hour.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Minute.NumberValue.CompareTo(second.Minute.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Second.NumberValue.CompareTo(second.Second.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Millisecond.NumberValue.CompareTo(second.Millisecond.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Microsecond.NumberValue.CompareTo(second.Microsecond.NumberValue);
        if (result != 0)
        {
            return result;
        }

        return first.Nanosecond.NumberValue.CompareTo(second.Nanosecond.NumberValue);
    }
}