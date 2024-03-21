using System.Net.Http.Json;
using System.Text.Json;
using Domain.Common;
using Domain.Users;

namespace Adapter.Users;

public class UsersAdapter(HttpClient httpClient) : IUsersAdapter
{
    public async Task RegisterUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Register, new { email, password });

        var res = await response.Content.ReadAsStringAsync();
        
        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        Console.WriteLine(res);
    }

    public async Task LoginUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Login, new { email, password, useSessionCookies = true });
        var res = await response.Content.ReadAsStringAsync();
        Console.WriteLine(res);
        response.EnsureSuccessStatusCode();
    }

    public Task LogoutUserAsync()
    {
        return Task.CompletedTask;
        /*var response = await httpClient.PostAsync(WhaleApiCatalog.Users.Logout);
        response.EnsureSuccessStatusCode();*/
    }
}