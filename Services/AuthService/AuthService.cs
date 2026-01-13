using PLACTECUGHH;
using PLACTECUGHH.DTOs.Auth;
using PLACTECUGHH.Models;
using PLACTECUGHH.Services.AuthService;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.Json;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private readonly Data _data;
    private readonly JsonSerializerOptions _jsonOptions;

    public AuthService(HttpClient client, Data data)
    {
        _client = client;
        _data = data;
        _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        try
        {
            var response = await _client.GetStringAsync(
                $"{_data.userData}/?email={Uri.EscapeDataString(email)}");

            var users = JsonSerializer.Deserialize<ObservableCollection<User>>(response, _jsonOptions);
            return users?.Any() == true;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return false;
        }
    }

    public async Task RegisterAsync(RegisterDTO dto)
    {
        var user = new User
        {
            email = dto.email,
            passWord = BCrypt.Net.BCrypt.HashPassword(dto.passWord)
        };

        var json = JsonSerializer.Serialize(user, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PostAsync(_data.userData, content);
    }
}
