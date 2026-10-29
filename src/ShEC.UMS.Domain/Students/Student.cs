namespace ShEC.UMS.Domain.Students;

public sealed class Student
{
    public Guid Id { get; private set; }

    public string StudentNumber { get; private set; } = string.Empty;

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    private Student()
    {
        // Reserved for ORM materialization.
    }

    private Student(
        string studentNumber,
        string firstName,
        string lastName)
    {
        Id = Guid.NewGuid();

        StudentNumber = NormalizeRequired(
            studentNumber,
            nameof(studentNumber),
            50);

        FirstName = NormalizeRequired(
            firstName,
            nameof(firstName),
            100);

        LastName = NormalizeRequired(
            lastName,
            nameof(lastName),
            100);
    }

    public static Student Create(
        string studentNumber,
        string firstName,
        string lastName)
    {
        return new Student(
            studentNumber,
            firstName,
            lastName);
    }

    private static string NormalizeRequired(
        string value,
        string parameterName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Value cannot be empty or whitespace.",
                parameterName);
        }

        var normalized = string.Join(
            ' ',
            value.Split(
                (char[]?)null,
                StringSplitOptions.RemoveEmptyEntries));

        if (normalized.Length > maxLength)
        {
            throw new ArgumentException(
                $"Value cannot exceed {maxLength} characters.",
                parameterName);
        }

        return normalized;
    }
}
