using Baro.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Baro.Services
{
    public static class CourseService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<Course> GetCourse(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            Course course= new Course();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "course/" + id));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    course = JsonSerializer.Deserialize<Course>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return course;
        }
       public static async Task<List<Course>> GetCourses()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            List<Course> Courses = new List<Course>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "course"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Courses = JsonSerializer.Deserialize<List<Course>>(content);
                    return Courses;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}"+ ex.Message);
            }
            return Courses;

        }
               public static async Task<List<Course>> GetTrendingCourses()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            List<Course> Courses = new List<Course>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "course/trending"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Courses = JsonSerializer.Deserialize<List<Course>>(content);
                    return Courses;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}"+ ex.Message);
            }
            return Courses;

        }

        public static async Task<Course> CreateCourse(Course data)
        {
            Course course = new Course();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "course"), new StringContent(JsonSerializer.Serialize<Course>(data), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    course = JsonSerializer.Deserialize<Course>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return course;
        }

        public static async Task<Course> UpdateCourse(int id, Course data)
        {
            Course course = new Course();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(new Uri(Constants.BackendURL + "course/" + id), new StringContent(JsonSerializer.Serialize<Course>(data), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    course = JsonSerializer.Deserialize<Course>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return course;
        }

        public static async Task DeleteCourse(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("Token", null));
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(Constants.BackendURL + "course/" + id));
                if (response.IsSuccessStatusCode)
                    Console.WriteLine(@"\tCourse successfully deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
