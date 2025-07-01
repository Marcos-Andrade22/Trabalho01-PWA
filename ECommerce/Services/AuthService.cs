using System.Text.Json;
using System.Text;

namespace ECommerce.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:5287/api/auth";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new { Username = username, Password = password };
                var json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{ApiUrl}/login", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            try
            {
                var registerData = new { Username = username, Email = email, Password = password };
                var json = JsonSerializer.Serialize(registerData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{ApiUrl}/register", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}