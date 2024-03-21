using Domain.Errors;
using FluentValidation.Results;

namespace Domain.Common;

public static class ValidationResultExtensions
{
    public static Error ToError(this ValidationResult validationResult)
    {
        return new Error(
            validationResult.Errors
                .Select(error => new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName))
                .Cast<IError>()
                .ToList());
    }
}