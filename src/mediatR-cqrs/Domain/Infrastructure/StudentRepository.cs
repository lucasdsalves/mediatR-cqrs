using mediatR_cqrs.Domain.Student.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatR_cqrs.Domain.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private List<StudentEntity> Students = new List<StudentEntity>();

        public StudentRepository()
        {
            Students = GetStudents();
        }

        public List<StudentEntity> GetStudents()
        {
            Students.Add(new StudentEntity(1, "Pedro", "Soares", "pedro@email.com"));
            Students.Add(new StudentEntity(2, "Maria", "Sanches", "maria@email.com"));
            Students.Add(new StudentEntity(3, "Manuel", "Ribeiro", "manul@email.com"));
            return Students;
        }

        public async Task Delete(int id)
        {
            int index = Students.FindIndex(m => m.Id == id);

            await Task.Run(() => Students.RemoveAt(index));
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            return await Task.FromResult(Students);
        }

        public async Task<StudentEntity> GetById(int id)
        {
            var result = Students.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task Save(StudentEntity student)
        {
            await Task.Run(() => Students.Add(student));
        }

        public async Task Update(int id, StudentEntity student)
        {
            int index = Students.FindIndex(m => m.Id == id);

            if (index >= 0)
                await Task.Run(() => Students[index] = student);
        }
    }
}
