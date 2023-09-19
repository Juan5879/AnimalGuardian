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

namespace ProyectoFinal.http
{
    internal class APIService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://DireccionOfrecidaPor.ngrok.io/api";

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
        public async Task<bool> UserAuth(User userauth)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(userauth), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/userauth", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<Authentication>(jsonResponse);

                    bool value = responseObject.value;
                    return value;
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud POST: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
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

                HttpResponseMessage response = await client.PostAsync($"{ApiBaseUrl}/post/user", content);
            }
        }

        //Foro

    }




    public class Authentication
    {
        public Boolean value { get; set; }
    }
}
