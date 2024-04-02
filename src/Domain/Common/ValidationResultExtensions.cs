using Domain.Errors;
using FluentValidation.Results;

namespace Domain.Common;

public static class ValidationResultExtensions
{
    public static DomainError ToError(this ValidationResult validationResult)
    {
        return new DomainError(
            "Validation error",
            "Validation error(s) occured",
            422,
            validationResult.Errors.Select(error => new DomainError(error.PropertyName, error.ErrorMessage)).ToList()); 
    }
}