using Domain.Common;
using Domain.Errors;
using Domain.Identity;
using MediatR;
using OneOf;

namespace Application.Identity.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<OneOf<Guid, DomainError>>;

public class LoginUser(IIdentityAdapter identityAdapter, LoginUserValidator registerUserValidator) : IRequestHandler<LoginUserCommand, OneOf<Guid, DomainError>>
{
    public async Task<OneOf<Guid, DomainError>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await registerUserValidator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid is false)
        {
            return validationResult.ToError();
        }
        
        var oneOf = await identityAdapter.LoginUserAsync(request.Email, request.Password);
        
        return Guid.NewGuid();
    }
}