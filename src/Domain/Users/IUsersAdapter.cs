namespace Domain.Users;

public interface IUsersAdapter
{
    public Task RegisterUserAsync(string email, string password);
    public Task LoginUserAsync(string email, string password);
    public Task LogoutUserAsync();
}