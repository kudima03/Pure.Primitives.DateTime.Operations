using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Date;
using Pure.Primitives.Number;
using Pure.Primitives.Random.DateTime;
using Pure.Primitives.Time;

namespace Pure.Primitives.DateTime.Operations.Tests;

public sealed record NotEqualConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        ITime currentTime = new CurrentTime();

        IBool equality = new NotEqualCondition(
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new NotEqualCondition(
            new DateTime(new CurrentDate()),
            new DateTime(new CurrentDate()));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnDifferentValues()
    {
        IBool equality = new NotEqualCondition(new RandomDateTimeCollection(new UShort(10)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllSameOneDifferentValue()
    {
        ITime currentTime = new CurrentTime();
        IBool equality = new NotEqualCondition(
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new DateTime(new CurrentDate(), currentTime),
            new RandomDateTime());

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnSingleElementInCollection()
    {
        IBool equality = new NotEqualCondition(new CurrentDateTime());
        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotEqualCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new RandomDateTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new RandomDateTime()).ToString());
    }
}