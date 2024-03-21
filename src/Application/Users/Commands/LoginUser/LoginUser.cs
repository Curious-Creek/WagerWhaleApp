using Domain.Common;
using Domain.Errors;
using Domain.Users;
using MediatR;
using OneOf;

namespace Application.Users.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<OneOf<Guid, Error>>;

public class LoginUser(IUsersAdapter usersAdapter, LoginUserValidator registerUserValidator) : IRequestHandler<LoginUserCommand, OneOf<Guid, Error>>
{
    public async Task<OneOf<Guid, Error>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await registerUserValidator.ValidateAsync(request);
        
        if (validationResult.IsValid is false)
        {
            return validationResult.ToError();
        }
        
        await usersAdapter.LoginUserAsync(request.Email, request.Password);
        
        return Guid.NewGuid();
    }
}