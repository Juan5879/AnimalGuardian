using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using ProyectoFinal.views;
using System.Net;
using Newtonsoft.Json;
using ProyectoFinal.model;
using System.Security;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace ProyectoFinal.http
{
    internal class APIService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://a8fc-38-51-89-131.ngrok-free.app/api";

        string error;
        string errorDetalles;

        public APIService()
        {
            _httpClient = new HttpClient();
        }


        //WikiAnimal
        public async Task<List<WikiData>> GetWikisAnimalAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/wikianimal");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<WikiData>>(json);
                    return data;
                }
                else
                {
                    return new List<WikiData>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<WikiData>();
            }
        }

        //User
        public async Task<User> CreateUserAsync(User newUser)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/user", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var createdUser = JsonConvert.DeserializeObject<User>(jsonResponse);
                    return createdUser;
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud POST: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorResponse);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public async Task<User> GetUserByEmail(string Email)
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/user/GetUserByEmail?email={Email}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var userData = JsonConvert.DeserializeObject<User>(json);
                return new User
                {
                    IdUser = userData.IdUser,
                    Name = userData.Name,
                    Email = userData.Email
                };
            }
            else
            {
                return null; 
            }
        }

        public async Task<bool> UpdateUserData(User user)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{ApiBaseUrl}/user/{user.IdUser}", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<UserAuthStatus> UserAuth(User userauth)
        {
            var userstatus = new UserAuthStatus
            {
                status = false
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(userauth), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{ApiBaseUrl}/auth", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                userstatus.status = JsonConvert.DeserializeObject<UserAuthStatus>(jsonResponse).status;
                return userstatus;
            }
            else
            {
                Console.WriteLine($"Error en la solicitud POST: {response.StatusCode}");
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorResponse);

                return userstatus;
            }
        }

        public async void PostUserAsync(string name, string email, string password)
        {
            var newuser = new User
            {
                IdUser = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password,
            };

            string jsonData = JsonConvert.SerializeObject(newuser);

            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{ApiBaseUrl}/user", content);
            }
        }

        //Foro
        public async Task<List<ForumContent>> GetForumContent()
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/forum");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ForumContent>>(json);
            return data;
        } 
        public async Task<bool> PostForum(ForumContent content)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/forum", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var createdPost = JsonConvert.DeserializeObject<ForumContent>(jsonResponse);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud POST: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorResponse);

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);  
                return false;
            }            
        }
    }

    public class Authentication
    {
        public Boolean value { get; set; }
    }
}
    