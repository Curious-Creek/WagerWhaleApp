namespace Domain.Identity;

public record ValidationProblemDetails(string Type, string Title, int Status, ProblemError Errors);