using mediatR_cqrs.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mediatR_cqrs.Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAll();

        Task<StudentDTO> GetById(int id);
    }
}
