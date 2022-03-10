using MediatR;

namespace mediatR_cqrs.Domain.Student.Command
{
    public class StudentDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
