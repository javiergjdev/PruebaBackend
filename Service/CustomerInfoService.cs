using System.Text.Json;
using PruebaBackend_Javier.Models;
using PruebaBackend_Javier.Repository;
using PruebaBackend_Javier.Service.Interface.Interface;
using PruebaBackend_Javier.Utils;

namespace PruebaBackend_Javier.Service.Interface;

public class CustomerInfoService(ICustomerDataProvider customerDataProvider) : ICustomerInfo
{
    private readonly ICustomerDataProvider _customerDataProvider = customerDataProvider;

    public CustomerInfoDto getCustomerImportantInfo()
    {
        CustomerInfoDto customerInfo = GetCustomer();
        customerInfo.addresses.Clear();
        
        return customerInfo;
    }

    public CustomerInfoDto getCustomerAddressSorted(string option, bool asc)
    {
        try
        {
            CustomerInfoDto customerInfo = GetCustomer();

            customerInfo.addresses = option switch
            {
                "address1" => asc
                    ? customerInfo.addresses.OrderBy(a => a.address1).ToList()
                    : customerInfo.addresses.OrderByDescending(a => a.address1).ToList(),
                "creationDate" => asc
                    ? customerInfo.addresses.OrderBy(a => a.creationDate).ToList()
                    : customerInfo.addresses.OrderByDescending(a => a.creationDate).ToList(),
                _ => throw new ArgumentException("Invalid sorting option", nameof(option))
            };

            return customerInfo;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error trying to sort customer addresses");

            throw;
        }
    }
    
    public CustomerInfoDto GetCustomerAddressSorted(string option, bool asc)
    {
        try
        {
            CustomerInfoDto customerInfo = GetCustomer();

            Func<Address, object> sortKeySelector = option switch
            {
                "address1" => a => a.address1,
                "creationDate" => a => a.creationDate,
                _ => throw new ArgumentException("Invalid sorting option", nameof(option))
            };

            customerInfo.addresses = asc
                ? customerInfo.addresses.OrderBy(sortKeySelector).ToList()
                : customerInfo.addresses.OrderByDescending(sortKeySelector).ToList();

            return customerInfo;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error trying to sort customer addresses: " + e.Message);
            throw;
        }
    }

    public Address? getCustomerPreferredAddressSorted()
    {
        try
        {
            CustomerInfoDto customerInfo = GetCustomer();

            var address = customerInfo.addresses.Find(a => a.preferred);

            return address;
        }
        catch (Exception e)
        {
            Console.WriteLine("failed to get customer preferred address");
            throw;
        }
    }
    
    public List<Address> getCustomerAddressByPC(string pc)
    {
        try
        {
            CustomerInfoDto customerInfo = GetCustomer();

            var address = customerInfo.addresses.FindAll(a => a.postalCode.Equals(pc));

            return address;
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to get customer address by Postal Code");
            throw;
        }
    }

    private CustomerInfoDto GetCustomer()
    {
        try
        {
            var customerJson = _customerDataProvider.RetrieveCustomerInfo();

            CustomerInfoDto? customerInfoDto = Format.DeserializeJson<CustomerInfoDto>(customerJson);
            
            return customerInfoDto;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error trying to getCustomer");
            throw;
        }
    }
    
   
}