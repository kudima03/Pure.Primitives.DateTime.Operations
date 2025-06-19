using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Date;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.DateTime.Operations.Tests;

public sealed record NotBeforeConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new NotBeforeCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new NotBeforeCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAscending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotBeforeCondition(
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 2))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),

            new DateTime(new Date.Date(new DateOnly(2000, 1, 2)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 2, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 3, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2001, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2002, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAscendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotBeforeCondition(
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 2))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),

            new DateTime(new Date.Date(new DateOnly(2000, 1, 2)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 2, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 3, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2001, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2002, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2002, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDescending()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotBeforeCondition(
            new DateTime(new Date.Date(new DateOnly(2002, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2001, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 3, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 2, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 1, 2)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),

            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSame()
    {
        IDate date = new Date.Date(new DateOnly(2000, 1, 1));

        IBool equality = new NotBeforeCondition(
            new DateTime(new Date.Date(new DateOnly(2002, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2001, 1, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 3, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 2, 1)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(new Date.Date(new DateOnly(2000, 1, 2)), new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),

            new DateTime(date, new Time.Time(new TimeOnly(2, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 2, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 2, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 2, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))),
            new DateTime(date, new Time.Time(new TimeOnly(1, 1, 1, 1, 1))));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new NotBeforeCondition(new CurrentDateTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotBeforeCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NotBeforeCondition(new RandomDateTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NotBeforeCondition(new RandomDateTime()).ToString());
    }
}