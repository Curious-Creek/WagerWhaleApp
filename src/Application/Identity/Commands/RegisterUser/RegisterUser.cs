using Domain.Common;
using Domain.Errors;
using Domain.Identity;
using MediatR;
using OneOf;

namespace Application.Identity.Commands.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password) : IRequest<OneOf<Guid, DomainError>>;

public class RegisterUserCommandHandler(IIdentityAdapter identityAdapter, RegisterUserValidator registerUserValidator) : IRequestHandler<RegisterUserCommand, OneOf<Guid, DomainError>>
{
    public async Task<OneOf<Guid, DomainError>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await registerUserValidator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid is false)
        {
            return validationResult.ToError();
        }
        
        var oneOf = await identityAdapter.RegisterUserAsync(request.Email, request.Password);
        
        return oneOf.Match<OneOf<Guid, DomainError>>(
            success => Guid.NewGuid(),
            validationProblemDetails => validationProblemDetails);
    }
}