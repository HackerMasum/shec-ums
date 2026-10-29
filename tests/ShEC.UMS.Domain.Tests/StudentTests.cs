using ShEC.UMS.Domain.Students;

namespace ShEC.UMS.Domain.Tests;

public sealed class StudentTests
{
    [Fact]
    public void Create_WithValidValues_CreatesStudent()
    {
        var student = Student.Create(
            "SHEC-2026-001",
            "Shah",
            "Ismail");

        Assert.NotEqual(Guid.Empty, student.Id);
        Assert.Equal("SHEC-2026-001", student.StudentNumber);
        Assert.Equal("Shah", student.FirstName);
        Assert.Equal("Ismail", student.LastName);
        Assert.Equal("Shah Ismail", student.FullName);
    }

    [Fact]
    public void Create_NormalizesWhitespace()
    {
        var student = Student.Create(
            "  SHEC-2026-001  ",
            "  Shah   Ismail ",
            " Talukdar  ");

        Assert.Equal("SHEC-2026-001", student.StudentNumber);
        Assert.Equal("Shah Ismail", student.FirstName);
        Assert.Equal("Talukdar", student.LastName);
        Assert.Equal("Shah Ismail Talukdar", student.FullName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithEmptyStudentNumber_Throws(
        string? studentNumber)
    {
        Assert.Throws<ArgumentException>(() =>
            Student.Create(studentNumber!, "First", "Last"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithEmptyFirstName_Throws(
        string? firstName)
    {
        Assert.Throws<ArgumentException>(() =>
            Student.Create("SHEC-001", firstName!, "Last"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithEmptyLastName_Throws(
        string? lastName)
    {
        Assert.Throws<ArgumentException>(() =>
            Student.Create("SHEC-001", "First", lastName!));
    }

    [Fact]
    public void Create_WithStudentNumberOver50Characters_Throws()
    {
        var studentNumber = new string('S', 51);

        Assert.Throws<ArgumentException>(() =>
            Student.Create(studentNumber, "First", "Last"));
    }

    [Fact]
    public void Create_WithNameOver100Characters_Throws()
    {
        var firstName = new string('A', 101);

        Assert.Throws<ArgumentException>(() =>
            Student.Create("SHEC-001", firstName, "Last"));
    }

    [Fact]
    public void Create_Twice_GeneratesDifferentIds()
    {
        var first = Student.Create("SHEC-001", "First", "Last");
        var second = Student.Create("SHEC-002", "First", "Last");

        Assert.NotEqual(first.Id, second.Id);
    }
}
