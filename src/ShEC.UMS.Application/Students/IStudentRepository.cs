using ShEC.UMS.Domain.Students;

namespace ShEC.UMS.Application.Students;

public interface IStudentRepository
{
    Task<IReadOnlyList<Student>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Student?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<bool> StudentNumberExistsAsync(
        string studentNumber,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Student student,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Student student,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Student student,
        CancellationToken cancellationToken = default);
}
