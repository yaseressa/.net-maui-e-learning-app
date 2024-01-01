using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baro.Services
{
    internal class AuthService
    {
        public class Token
        {
            public string token { get; set; }

        }
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> login(string email, string password)
        {
            string token = "";

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "auth/login"), new StringContent(JsonSerializer.Serialize(new Dictionary<string, string>{{ "email", email }, { "password", password }}), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    token = JsonSerializer.Deserialize<Token>(content).token;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return token;
        }
        public static async Task<string> signup(string name, string email, string password)
        {
            string token = "";

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "auth/signup"), new StringContent(JsonSerializer.Serialize(new Dictionary<string, string>{ {"name", name }, { "email", email }, { "password", password }}), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    token = JsonSerializer.Deserialize<Token>(content).token;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return token;
        }
    }
}
