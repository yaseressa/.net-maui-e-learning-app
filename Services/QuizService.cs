using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baro.Services
{
    class Quiz
    {
        public static class QuizService
        {
            private static readonly HttpClient _httpClient = new HttpClient();

            public static async Task<Quiz> GetQuiz(int id)
            {
                Quiz quiz = new Quiz();
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "quiz/" + id));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        quiz = JsonSerializer.Deserialize<Quiz>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return quiz;
            }
            public static async Task<List<Quiz>> GetQuizs()
            {
                List<Quiz> Quizs = new List<Quiz>();
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(Constants.BackendURL + "quiz"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Quizs = JsonSerializer.Deserialize<List<Quiz>>(content);
                        return Quizs;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}" + ex.Message);
                }
                return Quizs;

            }

            public static async Task<Quiz> CreateQuiz(Quiz data)
            {
                Quiz quiz = new Quiz();
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsync(new Uri(Constants.BackendURL + "quiz"), new StringContent(JsonSerializer.Serialize<Quiz>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        quiz = JsonSerializer.Deserialize<Quiz>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return quiz;
            }

            public static async Task<Quiz> UpdateQuiz(int id, Quiz data)
            {
                Quiz quiz = new Quiz();
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsync(new Uri(Constants.BackendURL + "quiz/" + id), new StringContent(JsonSerializer.Serialize<Quiz>(data), Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        quiz = JsonSerializer.Deserialize<Quiz>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }

                return quiz;
            }

            public static async Task DeleteQuiz(int id)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(Constants.BackendURL + "quiz/" + id));
                    if (response.IsSuccessStatusCode)
                        Console.WriteLine(@"\tQuiz successfully deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }
        }
    }
}
