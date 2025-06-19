using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Random.DateTime;
using Pure.Primitives.Time;

namespace Pure.Primitives.DateTime.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        ITime currentTime = new CurrentTime();

        IBool equality = new EqualCondition(
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new EqualCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition(new RandomDateTimeCollection(new UShort(10)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        ITime currentTime = new CurrentTime();
        IBool equality = new EqualCondition(
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new RandomDateTime());

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new EqualCondition(new CurrentDateTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new EqualCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new RandomDateTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new RandomDateTime()).ToString());
    }
}