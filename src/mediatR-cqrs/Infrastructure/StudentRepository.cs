using mediatR_cqrs.Domain.Aggregations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatR_cqrs.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> Students = new List<Student>();

        public StudentRepository()
        {
            Students = GetStudents();
        }

        public List<Student> GetStudents()
        {
            Students.Add(new Student(1, "Pedro", "Soares", "pedro@email.com"));
            Students.Add(new Student(2, "Maria", "Sanches", "maria@email.com"));
            Students.Add(new Student(3, "Manuel", "Ribeiro", "manul@email.com"));
            return Students;
        }

        public async Task Delete(int id)
        {
            int index = Students.FindIndex(m => m.Id == id);

            await Task.Run(() => Students.RemoveAt(index));
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Task.FromResult(Students);
        }

        public async Task<Student> GetById(int id)
        {
            var result = Students.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task Save(Student student)
        {
            await Task.Run(() => Students.Add(student));
        }

        public async Task Update(int id, Student student)
        {
            int index = Students.FindIndex(m => m.Id == id);

            if (index >= 0)
                await Task.Run(() => Students[index] = student);
        }
    }
}
