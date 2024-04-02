namespace Domain.Users;

public record User(Guid Id, string DisplayName, string Email, string? FirstName, string? LastName);