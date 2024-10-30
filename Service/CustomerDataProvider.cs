using PruebaBackend_Javier.Repository;
using PruebaBackend_Javier.Service.Interface.Interface;

namespace PruebaBackend_Javier.Service.Interface;

public class CustomerDataProvider(IHttpService httpService) : ICustomerDataProvider
{
    
    private IHttpService _httpService = httpService;
    public Task<string> RetrieveCustomerInfo()
    {
        try
        {
            var url = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer";

            var headers = new Dictionary<string, string>
            {
                { "Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=" }
            };
            
            var consumeServices = _httpService.ConsumeServices(null, url, HttpMethod.Get, headers);
            return consumeServices;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error trying to retrieve customer info");
            throw;
        }
    }
}