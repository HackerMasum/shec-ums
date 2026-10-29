using Microsoft.EntityFrameworkCore;
using ShEC.UMS.Application.Students;
using ShEC.UMS.Domain.Students;
using ShEC.UMS.Infrastructure.Persistence;

namespace ShEC.UMS.Infrastructure.Persistence.Repositories;

public sealed class StudentRepository(
    ShECUmsDbContext dbContext) : IStudentRepository
{
    public async Task<IReadOnlyList<Student>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Students
            .AsNoTracking()
            .OrderBy(student => student.StudentNumber)
            .ToListAsync(cancellationToken);
    }

    public Task<Student?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Students
            .FirstOrDefaultAsync(
                student => student.Id == id,
                cancellationToken);
    }

    public Task<bool> StudentNumberExistsAsync(
        string studentNumber,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Students
            .AnyAsync(
                student => student.StudentNumber == studentNumber,
                cancellationToken);
    }

    public async Task AddAsync(
        Student student,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Students.AddAsync(student, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Student student,
        CancellationToken cancellationToken = default)
    {
        dbContext.Students.Update(student);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        Student student,
        CancellationToken cancellationToken = default)
    {
        dbContext.Students.Remove(student);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
