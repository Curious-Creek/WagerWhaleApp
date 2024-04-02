using Domain.Events;
using MediatR;

namespace Application.Identity.EventHandlers;

public class UserLoginEventHandler : INotificationHandler<UserLoginEvent>
{
    public Task Handle(UserLoginEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}