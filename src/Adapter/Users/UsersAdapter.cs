using System.Net.Http.Json;
using Domain.Common;
using Domain.Users;

namespace Adapter.Users;

public class UsersAdapter(HttpClient httpClient) : IUsersAdapter
{
    public async Task RegisterUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Register, new { email, password });

        var res = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine("Hello2");
        Console.WriteLine(res);
        
        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        HttpErrorWrapper? error = await response.Content.ReadFromJsonAsync<HttpErrorWrapper>();
        
        foreach (var httpError in error.Errors)
        {
            Console.WriteLine(httpError.ErrorTitle);
            
            foreach (var errorMessage in httpError.ErrorMessages)
            {
                Console.WriteLine(errorMessage);
            }
        }
    }

    public async Task LoginUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Login, new { email, password });
        response.EnsureSuccessStatusCode();
    }

    public Task LogoutUserAsync()
    {
        return Task.CompletedTask;
        /*var response = await httpClient.PostAsync(WhaleApiCatalog.Users.Logout);
        response.EnsureSuccessStatusCode();*/
    }
}