using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Date;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.DateTime.Operations.Tests;

public sealed record AfterConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new AfterCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate())
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new AfterCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate())
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesTrueResultOnAscending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new AfterCondition(
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 2))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(
                new Date.Date(new DateOnly(2000, 1, 2)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 2, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 3, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2001, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2002, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            )
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new AfterCondition(
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 2))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(
                new Date.Date(new DateOnly(2000, 1, 2)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 2, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 3, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2001, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2002, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2002, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            )
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDescending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new AfterCondition(
            new DateTime(
                new Date.Date(new DateOnly(2002, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2001, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 3, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 2, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 1, 2)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1)))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new AfterCondition(
            new DateTime(
                new Date.Date(new DateOnly(2002, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2001, 1, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 3, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 2, 1)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(
                new Date.Date(new DateOnly(2000, 1, 2)),
                new Time.Time(new TimeOnly(1, 1, 1, 1, 1))
            ),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1)))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new AfterCondition(new CurrentDateTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new AfterCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AfterCondition(new RandomDateTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AfterCondition(new RandomDateTime()).ToString()
        );
    }
}
