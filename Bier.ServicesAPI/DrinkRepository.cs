using Bier.Models;
using Bier.ServicesAPI.Bases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Bier.ServicesAPI
{
    public class DrinkRepository : BaseRepository, IDrinkRepository
    {
        public DrinkRepository() : base("Drinks")
        {
        }

       

        

        private string GetJsonContent(HttpResponseMessage response)
        {
            Task<string> content = response.Content.ReadAsStringAsync();
            content.Wait();
            return content.Result;
        }

        public Drink Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drink> Get()
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.GetAsync);
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                string jsonString = GetJsonContent(response);
                return JsonConvert.DeserializeObject<IEnumerable<Drink>>(jsonString);
            }
        }

        public Drink Get(int id)
        {
            throw new NotImplementedException();
        }

        public Drink Insert(Drink entity)
        {
            JsonContent entityJson = JsonContent.Create(entity);
            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.PostAsync, entityJson);
                if(!response.IsSuccessStatusCode) throw new HttpRequestException();
                string jsonString = GetJsonContent(response);
                return JsonConvert.DeserializeObject<Drink>(jsonString);
            }
        }

        public Drink Update(int id, Drink entity)
        {
            throw new NotImplementedException();
        }
    }
}
