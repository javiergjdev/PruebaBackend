using PruebaBackend_Javier.Models;

namespace PruebaBackend_Javier.Service.Interface.Interface;

public interface ICustomerInfo
{
    CustomerInfoDto getCustomerImportantInfo();
    CustomerInfoDto getCustomerAddressSorted(string option, bool asc);
    Address? getCustomerPreferredAddressSorted();

    List<Address> getCustomerAddressByPC(string pc);
}