using MediatR;

namespace mediatR_cqrs.Application.Command.Student
{
    public class StudentDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
