using MediatR;

namespace mediatR_cqrs.Domain.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Error { get; set; }

        public string ErrorStack { get; set; }
    }
}
