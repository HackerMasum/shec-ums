using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShEC.UMS.Domain.Students;

namespace ShEC.UMS.Infrastructure.Persistence.Configurations;

public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(student => student.Id);

        builder.Property(student => student.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(student => student.StudentNumber)
            .HasColumnName("student_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(student => student.StudentNumber)
            .IsUnique();

        builder.Property(student => student.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(student => student.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Ignore(student => student.FullName);
    }
}
