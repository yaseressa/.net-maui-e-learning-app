using Baro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baro.Services
{

        public static class UserService
        {
            private static readonly HttpClient _httpClient = new HttpClient();

            public static async Task<User> GetUser(string email)
            {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            User user = new User();
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "user/" + email));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<User>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return user;
            }

            public static async Task<User> CreateUser(User data)
            {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            User user = new User();
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "user"), new StringContent(JsonSerializer.Serialize<User>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<User>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return user;
            }

            public static async Task<User> UpdateUser(int id, User data)
            {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            User user = new User();
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsync(new Uri(Constants.BackendURL + "user/" + id), new StringContent(JsonSerializer.Serialize<User>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<User>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return user;
            }
            public static async Task<User> EnrollCourse(int id, int courseId)
            {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            User user = new User();
            try
            {
                    HttpResponseMessage response = await _httpClient.PutAsync(new Uri(Constants.BackendURL + "user/" + id + "/" + courseId), new StringContent("", Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<User>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return user;
            }

            public static async Task DeleteUser(int id)
            {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            try
            {
                    HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(Constants.BackendURL + "user/" + id));
                    if (response.IsSuccessStatusCode)
                        Console.WriteLine(@"\tUser successfully deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }
        }
    }
