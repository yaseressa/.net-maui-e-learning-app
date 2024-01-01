using Baro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baro.Services
{

        public static class LessonService
        {
            private static readonly HttpClient _httpClient = new HttpClient();

            public static async Task<Lesson> GetLesson(int id)
            {
                Lesson lesson = new Lesson();
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "lesson/" + id));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        lesson = JsonSerializer.Deserialize<Lesson>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return lesson;
            }
            public static async Task<List<Lesson>> GetLessons()
            {
                List<Lesson> Lessons = new List<Lesson>();
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "lesson"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Lessons = JsonSerializer.Deserialize<List<Lesson>>(content);
                        return Lessons;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}" + ex.Message);
                }
                return Lessons;

            }

            public static async Task<Lesson> CreateLesson(Lesson data)
            {
                Lesson lesson = new Lesson();
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "lesson"), new StringContent(JsonSerializer.Serialize<Lesson>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        lesson = JsonSerializer.Deserialize<Lesson>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return lesson;
            }

            public static async Task<Lesson> UpdateLesson(int id, Lesson data)
            {
                Lesson lesson = new Lesson();
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsync(new Uri(Constants.BackendURL + "lesson/" + id), new StringContent(JsonSerializer.Serialize<Lesson>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        lesson = JsonSerializer.Deserialize<Lesson>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return lesson;
            }

            public static async Task DeleteLesson(int id)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(Constants.BackendURL + "lesson/" + id));
                    if (response.IsSuccessStatusCode)
                        Console.WriteLine(@"\tLesson successfully deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }
        }
    }

