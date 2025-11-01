using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using Academy.Infrastructure.DataContext;

namespace Academy.Infrastructure.Repositories;

public class StudentRepository : EfCoreRepositoryAsync<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}