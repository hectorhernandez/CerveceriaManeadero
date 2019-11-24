using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CerveceriaManeadero.Models;
using Newtonsoft.Json;

namespace CerveceriaManeadero.Services
{
    public class UserService
    {
        const string ApiURL = "http://10.0.2.2:52373";
        private HttpClient _client;

        public List<User> Items { get; private set; }

        public UserService()
        {
            _client = new HttpClient();
        }

        public async Task<User> Login(string username, string password)
        {
            try
            {
                string url = "/api/user/login";
                var client = new HttpClient();

                var uri = new Uri(ApiURL);
                client.BaseAddress = uri;
                var requestBody = new LoginRequest
                {
                    Username = username,
                    Password = password
                };
                var json = JsonConvert.SerializeObject(requestBody);
                //var content = new StringContent(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;

                HttpResponseMessage response = null;

                response = await client.SendAsync(request);

                User user = null;
                System.Diagnostics.Debug.WriteLine(response);
                if(response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(responseContent);
                }

                return user;

            }
            catch(Java.Net.ProtocolException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex; 
            }
            
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}