using Bier.Models;
using Bier.ServicesAPI.Bases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bier.ServicesAPI
{
    public class UserRepository : BaseRepository
    {
        public UserRepository() : base("Users")
        {
        }

        public UserPublic Login(string mail, string password)
        {
            using(HttpClient client = CreateHttpClient())
            {
                Task<HttpResponseMessage> httpResponse = client.PostAsync($"users/login?email={mail}&password={password}", null);
                httpResponse.Wait();
                HttpResponseMessage response = httpResponse.Result;
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                string json = GetJsonContent(response);
                UserPublic user = JsonConvert.DeserializeObject<UserPublic>(json);
                if (user != null) Environment.token = user.Token;
                return user;
            }
        }
    }
}
