using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PruebaBackend_Javier.Repository;

public class HttpService(HttpClient client) : IHttpService
{
    public async Task<string> ConsumeServices(string? body, string url, HttpMethod method, Dictionary<string, string> headers)
    {
        try
        {
            var request = BuildRequest(body, url, method, headers);

            HttpResponseMessage response = await client.SendAsync(request);

            ValidateResponse(response);

            string responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static HttpRequestMessage BuildRequest(string? body, string url, HttpMethod method, Dictionary<string, string> headers)
    {
        try
        {
            var request = new HttpRequestMessage(method, url);
            
            foreach (var keyValuePair in headers)
            {
                request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }            

            if (body != null)
            {
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var bodyRequest = new StringContent(JsonSerializer.Serialize(body, options), Encoding.UTF8,  "application/json");
                request.Content = bodyRequest;
            }

            return request;
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed trying to build request");
            throw;
        }
    }

    private void ValidateResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new AuthenticationException($"User not autenticated: {response.Content}");
        }

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new ArgumentException($"Error HTTP: {response.StatusCode}");
        }

        if (!response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            throw new ApplicationException($"Error in response from server: {responseContent}");
        }
    }
}