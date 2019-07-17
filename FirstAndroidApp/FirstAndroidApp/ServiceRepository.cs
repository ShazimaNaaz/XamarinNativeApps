using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using FirstAndroidApp.Dto;
using Newtonsoft.Json;

namespace FirstAndroidApp
{
    public class ServiceRepository
    {
        HttpClient _client;

        public ServiceRepository()
        {
            _client = new HttpClient();
        }

        public async Task<CardDetailsDto> ConsumeWebservices(string uri)
        {
            CardDetailsDto weatherData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<CardDetailsDto>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return weatherData;
        }

    }
}
