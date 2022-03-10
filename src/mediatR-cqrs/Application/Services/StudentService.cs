using mediatR_cqrs.Application.DTOs;
using mediatR_cqrs.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatR_cqrs.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAll()
        {
            var allStudents = await _studentRepository.GetAll();

            return allStudents.Select(a => (StudentDTO)a).OrderBy(a => a.FirstName).ToList();
        }

        public async Task<StudentDTO> GetById(int id)
        {
            var studentById = await _studentRepository.GetById(id);

            return (StudentDTO)studentById;
        }
    }
}
