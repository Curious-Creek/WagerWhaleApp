using Domain.Common;
using Domain.Users;

namespace Domain.Events;

public class UserLoginEvent(User user) : BaseEvent
{
    public User User { get; } = user;
}