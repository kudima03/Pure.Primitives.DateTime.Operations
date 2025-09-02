using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.DateTime;

namespace Pure.Primitives.DateTime.Operations;

public sealed record EqualCondition : IBool
{
    private readonly IEnumerable<IDateTime> _values;

    public EqualCondition(params IEnumerable<IDateTime> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            int distinctCount = _values
                .DistinctBy(x =>
                    (
                        x.Year.NumberValue,
                        x.Month.NumberValue,
                        x.Day.NumberValue,
                        x.Hour.NumberValue,
                        x.Minute.NumberValue,
                        x.Second.NumberValue,
                        x.Millisecond.NumberValue,
                        x.Microsecond.NumberValue,
                        x.Nanosecond.NumberValue
                    )
                )
                .Count();

            return distinctCount == 0
                ? throw new ArgumentException()
                : distinctCount == 1;
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
