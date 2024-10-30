using System; 
namespace PruebaBackend_Javier.Models{ 

    public class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string addressId { get; set; }
        public string city { get; set; }
        public object companyName { get; set; }
        public string countryCode { get; set; }
        public DateTime creationDate { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public object jobTitle { get; set; }
        public DateTime lastModified { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string postalCode { get; set; }
        public object postBox { get; set; }
        public bool preferred { get; set; }
        public object salutation { get; set; }
        public object secondName { get; set; }
        public string stateCode { get; set; }
        public object suite { get; set; }
        public object title { get; set; }
        public bool c_esFiscal { get; set; }
        public object c_razonSocial { get; set; }
        public object c_rfc { get; set; }
        public object c_usoCFDI { get; set; }
        public string c_colonia { get; set; }
        public string c_streetNumber { get; set; }
        public object c_buildingNumber { get; set; }
        public double c_latitude { get; set; }
        public double c_longitude { get; set; }
        public string c_reference { get; set; }
        public object errorMessage { get; set; }
    }

}