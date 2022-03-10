using MediatR;
using mediatR_cqrs.Domain.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR_cqrs.Domain.EventsHandlers
{
    public class SuccessHandler : INotificationHandler<StudentActionNotification>
    {
        public Task Handle(StudentActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                System.Console.WriteLine("The sudent {0} {1} was {2} successfully",
                    notification.FirstName, notification.LastName, notification.Action.ToString().ToLower());
            });
        }
    }
}
