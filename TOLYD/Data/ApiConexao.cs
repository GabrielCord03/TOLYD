using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TOLYD.Classes;
using Newtonsoft.Json;

namespace TOLYD.Data
{
    public class ApiConexao
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task SyncUserAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://your-api-url.com/sync", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao sincronizar com o servidor.");
            }
        }
    }
}
