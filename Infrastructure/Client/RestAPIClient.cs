using Infrastructure.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Client
{
    public class RestAPIClient
    {
        private const string URL = "https://localhost:5001/api/TextFinder";
        
        public async Task<IEnumerable<WordCount>> GetResponseAsync(Uri request, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {     
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // Get data response
                    var response = await client.GetAsync(request, cancellationToken);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<WordCount>>(result);
                        return data;
                    }
                }
            }
            catch(Exception ex)
            {
                //to log
                throw;
            }

            return await Task.FromResult<IEnumerable<WordCount>>(null);
        }
    }
}
