using mediatR_cqrs.Domain.Aggregations;

namespace mediatR_cqrs.Application.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static explicit operator StudentDTO(Student v)
        {
            return new StudentDTO
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                Email = v.Email
            };
        }
    }
}
