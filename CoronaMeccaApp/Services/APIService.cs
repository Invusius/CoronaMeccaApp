using CoronaMeccaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.Services
{
    public class APIService : IAPIService
    {

        HttpClient client;   
        
        public APIService()
        {

            client = new HttpClient();
            


        }

        public async Task<bool> CreateBox(CreateBox createBox)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(createBox), Encoding.UTF8, "application/json"))
            {
                string token = await SecureStorage.Default.GetAsync("oauth_token");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");

                HttpResponseMessage response = await client.PostAsync("https://vacapi.semeicardia.online/api/boxes", content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                var jsonstring = await response.Content.ReadAsStringAsync();
                if (jsonstring != null)
                {
                    
                    return true;

                }
                else
                {

                    return false;
                }
            }
        }

        public async Task<Box> GetboxAsync(int id)
        {
            try
             {

                string token = await SecureStorage.Default.GetAsync("oauth_token");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");

                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/boxes/name/"+ id);

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                Box box = JsonConvert.DeserializeObject<Box>(jsonstring);
                if (box != null)
                {
                    return box;

                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }

        }
    

        public async Task<bool> LoginAsync(User user)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
            {

                HttpResponseMessage response = await client.PostAsync("https://vacapi.semeicardia.online/api/authenticate/app", content);
           
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var jsonstring = await response.Content.ReadAsStringAsync();

                dynamic values = JsonConvert.DeserializeObject<dynamic>(jsonstring);

                if (jsonstring != null)
                {
                    string usertoken = values[1].token;
                    //await settoken(values[1].token); 
                    SecureStorage.Default.RemoveAll();

                    await SecureStorage.Default.SetAsync("oauth_token", usertoken);

                    
                    return true;

                }
                else
                {

                    return false;
                }
            }

        }

        public async Task<List<Position>> PositionsListAsync()
        {
            try
            {

                string token = await SecureStorage.Default.GetAsync("oauth_token");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");


                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/positions") ;

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                var positions = JsonConvert.DeserializeObject<IEnumerable<Position>>(jsonstring);

                return positions.ToList();
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }
        }
        public async Task<List<Position>> ZonePositionsListAsync(int id)
        {
            try
            {

                string token = await SecureStorage.Default.GetAsync("oauth_token");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");


                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/positions/zone/" + id);

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                var positions = JsonConvert.DeserializeObject<IEnumerable<Position>>(jsonstring);

                return positions.ToList();
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }
        }
        public async Task<List<Types>> TyoesListAsync()
        {
            try
            {

                string token = await SecureStorage.Default.GetAsync("oauth_token");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");


                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/types");

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                var types = JsonConvert.DeserializeObject<IEnumerable<Types>>(jsonstring);

                return types.ToList();
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }
        }

        public async Task<List<Zone>> ZoneListAsync()
        
        {
            try
            {

                string token = await SecureStorage.Default.GetAsync("oauth_token"); 
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");
                    
                    
                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/zones");

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                var Zones = JsonConvert.DeserializeObject<IEnumerable<Zone>>(jsonstring);

                return Zones.ToList();
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }

        }

        public async Task<bool> UpdateBox(int id , CreateBox UpdateBox)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(UpdateBox), Encoding.UTF8, "application/json"))
            {
                string token = await SecureStorage.Default.GetAsync("oauth_token");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");

                HttpResponseMessage response = await client.PutAsync("https://vacapi.semeicardia.online/api/boxes/" + id, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var jsonstring = await response.Content.ReadAsStringAsync();

                //dynamic values = JsonConvert.DeserializeObject<dynamic>(jsonstring);

                if (jsonstring != null)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
        }

        public async Task<Zone> ZoneAsync(int id)
        {
            try
            {

                string token = await SecureStorage.Default.GetAsync("oauth_token");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{token}");


                HttpResponseMessage response = await client.GetAsync("https://vacapi.semeicardia.online/api/zones/"+id);

                response.EnsureSuccessStatusCode();
                var jsonstring = await response.Content.ReadAsStringAsync();

                var Zone = JsonConvert.DeserializeObject<Zone>(jsonstring);


                return Zone;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine("error" + e);
                return null;

            }
        }
    }
}
