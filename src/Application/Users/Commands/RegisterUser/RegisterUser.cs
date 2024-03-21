using Domain.Users;
using MediatR;
using OneOf;

namespace Application.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password) : IRequest<OneOf<Guid, List<string>>>;

public class RegisterUserCommandHandler(IUsersAdapter usersAdapter, RegisterUserValidator registerUserValidator) : IRequestHandler<RegisterUserCommand, OneOf<Guid, List<string>>>
{
    public async Task<OneOf<Guid, List<string>>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await registerUserValidator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid is false)
        {
            return validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        
        await usersAdapter.RegisterUserAsync(request.Email, request.Password);
        
        return Guid.NewGuid();
    }
}