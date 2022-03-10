using MediatR;

namespace mediatR_cqrs.Domain.Student.Command
{
    public class StudentCreateCommand : IRequest<string>
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
