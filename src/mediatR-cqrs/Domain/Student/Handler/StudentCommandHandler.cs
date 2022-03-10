using MediatR;
using mediatR_cqrs.Domain.Infrastructure;
using mediatR_cqrs.Domain.Notifications;
using mediatR_cqrs.Domain.Student.Command;
using mediatR_cqrs.Domain.Student.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR_cqrs.Domain.Student.Handler
{
    public class StudentCommandHandler : IRequestHandler<StudentCreateCommand, string>,
         IRequestHandler<StudentUpdateCommand, string>,
         IRequestHandler<StudentDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IStudentRepository _studentRepository;

        public StudentCommandHandler(IMediator mediator, IStudentRepository studentRepository)
        {
            _mediator = mediator;
            _studentRepository = studentRepository;
        }

        public async Task<string> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentEntity(request.Id, request.FirstName, request.LastName, request.Email);

            await _studentRepository.Save(student);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Created
            }, cancellationToken);

            return await Task.FromResult("Student save successfully.");
        }

        public async Task<string> Handle(StudentDeleteCommand request, CancellationToken cancellationToken)
        {
            var client = await _studentRepository.GetById(request.Id);

            await _studentRepository.Delete(request.Id);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Action = ActionNotification.Deleted
            }, cancellationToken);

            return await Task.FromResult("Student deleted successfully.");
        }

        public async Task<string> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentEntity(request.Id, request.FirstName, request.LastName, request.Email);

            await _studentRepository.Update(request.Id, student);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Updated
            }, cancellationToken);

            return await Task.FromResult("Student updated successfully.");
        }
    }
}
