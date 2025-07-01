using System.Net.Http.Json;
using System.Text.Json;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://localhost:5287/api/auth";
        private UserInfo? _currentUser;
        private bool _isAuthenticated = false;

        public event Action? OnAuthStateChanged;

        public bool IsAuthenticated => _isAuthenticated;
        public UserInfo? CurrentUser => _currentUser;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            try
            {
                var registerRequest = new RegisterRequest
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/register", registerRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Register failed: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Register exception: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Login successful");
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response content: " + responseContent);
                    try
                    {
                        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (loginResponse?.Success == true && loginResponse.User != null)
                        {
                            SetAuthenticatedUser(loginResponse.User);
                        }
                        else
                        {
                            SetAuthenticatedUser(new UserInfo { Username = username });
                        }
                    }
                    catch
                    {
                        SetAuthenticatedUser(new UserInfo { Username = username });
                    }

                    return true;
                }
                else
                {
                     Console.WriteLine("Login failed with status code: " + response.StatusCode);
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Login failed: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login exception: {ex.Message}");
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            try
            { 
                _currentUser = null;
                _isAuthenticated = false;
                NotifyAuthStateChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout exception: {ex.Message}");
                _currentUser = null;
                _isAuthenticated = false;
                NotifyAuthStateChanged();
            }
        }

        public void SetAuthenticatedUser(UserInfo user)
        {
            _currentUser = user;
            _isAuthenticated = true;
            NotifyAuthStateChanged();
        }

        private void NotifyAuthStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public UserInfo? User { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
    }
}