using mediatR_cqrs.Domain.Student.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mediatR_cqrs.Domain.Infrastructure
{
    public interface IStudentRepository
    {
        Task Save(StudentEntity student);
        Task Update(int id, StudentEntity student);
        Task Delete(int id);
        Task<StudentEntity> GetById(int id);
        Task<IEnumerable<StudentEntity>> GetAll();
    }
}
