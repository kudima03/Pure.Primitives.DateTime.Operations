﻿using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.DateTime;

namespace Pure.Primitives.DateTime.Operations;

public sealed record AfterCondition : IBool
{
    private readonly IComparer<IDateTime> _comparer;

    private readonly IEnumerable<IDateTime> _values;

    public AfterCondition(params IDateTime[] values) : this(values.AsReadOnly()) { }

    public AfterCondition(IEnumerable<IDateTime> values) : this(values, new DateTimeComparer()) { }

    private AfterCondition(IEnumerable<IDateTime> values, IComparer<IDateTime> comparer)
    {
        _values = values;
        _comparer = comparer;
    }

    bool IBool.BoolValue
    {
        get
        {
            using IEnumerator<IDateTime> enumerator = _values.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new ArgumentException();
            }

            IDateTime previous = enumerator.Current;

            while (enumerator.MoveNext())
            {
                if (_comparer.Compare(previous, enumerator.Current) >= 0)
                {
                    return false;
                }

                previous = enumerator.Current;
            }

            return true;
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