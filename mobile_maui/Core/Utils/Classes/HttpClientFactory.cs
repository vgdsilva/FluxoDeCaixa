using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Utils.Classes;

public class HttpClientFactory
{

    static HttpClientFactory _instance;

    public static HttpClientFactory HttpClient => _instance ?? (_instance = new HttpClientFactory());

    public async Task<T> PostAsync<T>(string url, object data)
    {
        using ( HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromMinutes(60) } )
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            using ( StringContent content = new StringContent(jsonContent, Encoding.UTF8, "") )
            using ( HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(url, content).ConfigureAwait(false))
            using ( Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync() )
            using ( StreamReader streamReader = new StreamReader(stream) )
            using ( JsonTextReader jsonTextReader = new JsonTextReader(streamReader) )
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault();
                return jsonSerializer.Deserialize<T>(jsonTextReader);
            }
        }
    }

    public async Task<T> GetAsync<T>(string url)
    {
        using ( HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromMinutes(60) } )
        {
            using ( HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url).ConfigureAwait(false) )
            {
                using ( Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync() )
                using ( StreamReader streamReader = new StreamReader(stream) )
                using ( JsonTextReader jsonTextReader = new JsonTextReader(streamReader) )
                {
                    JsonSerializer jsonSerializer = JsonSerializer.CreateDefault();
                    return jsonSerializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}
