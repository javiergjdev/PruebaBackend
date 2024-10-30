namespace PruebaBackend_Javier.Service.Interface.Interface;

public interface ICustomerDataProvider
{
    Task<string> RetrieveCustomerInfo();
}