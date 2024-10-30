using Microsoft.AspNetCore.Mvc;
using PruebaBackend_Javier.Service.Interface.Interface;

namespace PruebaBackend_Javier.Controllers;


[ApiController]
[Route("[controller]")]
public class CustomerInformationController(ICustomerInfo customerInfo) : ControllerBase
{
    private ICustomerInfo _customerInfo = customerInfo;

    [HttpGet]
    [Route("get_customer_information")]
    public IActionResult Save()
    {
        try
        {
            var customerImportantInfo = _customerInfo.getCustomerImportantInfo();

            return new OkObjectResult(customerImportantInfo);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }    
    
    [HttpGet]
    [Route("get_customer_address")]
    public IActionResult getCustomerAddressSorted([FromQuery] string option, bool asc)
    {
        try
        {
            var customerImportantInfo = _customerInfo.getCustomerAddressSorted(option, asc);

            return new OkObjectResult(customerImportantInfo);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    } 
    
    [HttpGet]
    [Route("get_customer_preferred_address")]
    public IActionResult getCustomerPreferredAddressSorted()
    {
        try
        {
            var customerImportantInfo = _customerInfo.getCustomerPreferredAddressSorted();

            return new OkObjectResult(customerImportantInfo);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    } 
    
    [HttpGet]
    [Route("get_customer_address_postal_code")]
    public IActionResult getCustomerPreferredAddressSorted([FromQuery] string postalCode)
    {
        try
        {
            var customerImportantInfo = _customerInfo.getCustomerAddressByPC(postalCode);

            return new OkObjectResult(customerImportantInfo);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }    
}