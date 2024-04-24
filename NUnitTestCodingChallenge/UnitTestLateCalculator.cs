using ClassLibrary;

namespace NUnitTestCodingChallenge;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void TestCalculateLate_SignInAfterShiftEnd()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 17, 15, 0);
        DateTime? leaveFrom = null;
        DateTime? leaveTo = null;

        TimeSpan expectedLate = TimeSpan.FromHours(8) + TimeSpan.FromMinutes(15);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInBeforeBreak()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 8, 30, 0);
        DateTime? leaveFrom = null;
        DateTime? leaveTo = null;

        TimeSpan expectedLate = TimeSpan.FromMinutes(30);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInDuringBreak()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 12, 30, 0);
        DateTime? leaveFrom = null;
        DateTime? leaveTo = null;

        TimeSpan expectedLate = TimeSpan.FromHours(4);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInAfterBreak()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 14, 30, 0);
        DateTime? leaveFrom = null;
        DateTime? leaveTo = null;

        TimeSpan expectedLate = TimeSpan.FromHours(5) + TimeSpan.FromMinutes(30);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInDuringLeave()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 9, 0, 0);
        DateTime leaveFrom = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime leaveTo = new DateTime(2024, 4, 24, 10, 0, 0);

        TimeSpan expectedLate = TimeSpan.Zero;
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInDuringAnyLeave()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 9, 30, 0);
        DateTime leaveFrom = new DateTime(2024, 4, 24, 9, 0, 0);
        DateTime leaveTo = new DateTime(2024, 4, 24, 11, 0, 0);

        TimeSpan expectedLate = TimeSpan.FromHours(1);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInBeforeLeave()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 8, 30, 0);
        DateTime leaveFrom = new DateTime(2024, 4, 24, 9, 0, 0);
        DateTime leaveTo = new DateTime(2024, 4, 24, 11, 0, 0);

        TimeSpan expectedLate = TimeSpan.FromMinutes(30);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

    [Test]
    public void TestCalculateLate_SignInAfterLeave()
    {
        DateTime shiftStart = new DateTime(2024, 4, 24, 8, 0, 0);
        DateTime shiftEnd = new DateTime(2024, 4, 24, 17, 0, 0);
        DateTime breakStart = new DateTime(2024, 4, 24, 12, 0, 0);
        DateTime breakEnd = new DateTime(2024, 4, 24, 13, 0, 0);
        DateTime signIn = new DateTime(2024, 4, 24, 14, 30, 0);
        DateTime leaveFrom = new DateTime(2024, 4, 24, 9, 0, 0);
        DateTime leaveTo = new DateTime(2024, 4, 24, 11, 0, 0);

        TimeSpan expectedLate = TimeSpan.FromMinutes(320);
        TimeSpan actualLate = LateCalculator.CalculateLate(shiftStart, shiftEnd, breakStart, breakEnd, signIn, leaveFrom, leaveTo);

        Assert.AreEqual(expectedLate, actualLate);
    }

}
