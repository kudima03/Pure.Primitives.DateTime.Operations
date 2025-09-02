using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Date;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.DateTime.Operations.Tests;

public sealed record NotAfterConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new NotAfterCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate())
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new NotAfterCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate())
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotAfterCondition(
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

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotAfterCondition(
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
    public void TakesPositiveResultOnDescending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotAfterCondition(
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

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllDescendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotAfterCondition(
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

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new NotAfterCondition(new CurrentDateTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotAfterCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NotAfterCondition(new RandomDateTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NotAfterCondition(new RandomDateTime()).ToString()
        );
    }
}
