using mediatR_cqrs.Domain.Aggregations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mediatR_cqrs.Infrastructure
{
    public interface IStudentRepository
    {
        Task Save(Student student);
        Task Update(int id, Student student);
        Task Delete(int id);
        Task<Student> GetById(int id);
        Task<IEnumerable<Student>> GetAll();
    }
}
