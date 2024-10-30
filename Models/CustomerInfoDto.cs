using System.Collections.Generic; 
using System; 
namespace PruebaBackend_Javier.Models{ 

    public class CustomerInfoDto
    {
        public string authType { get; set; }
        public DateTime creationDate { get; set; }
        public string customerId { get; set; }
        public string customerNo { get; set; }
        public string email { get; set; }
        public bool enabled { get; set; }
        public string firstName { get; set; }
        public DateTime lastLoginTime { get; set; }
        public DateTime lastModified { get; set; }
        public string lastName { get; set; }
        public DateTime lastVisitTime { get; set; }
        public string login { get; set; }
        public string phoneHome { get; set; }
        public string phoneMobile { get; set; }
        public DateTime previousLoginTime { get; set; }
        public DateTime previousVisitTime { get; set; }
        public string c_defaultDeliveryHome { get; set; }
        public bool c_defaultDeliveryStore { get; set; }
        public object c_doubleOptinLoyaltyResult { get; set; }
        public object c_doubleOptinAction { get; set; }
        public string c_fatherName { get; set; }
        public string c_preferredPostalCode { get; set; }
        public string c_preferredStoreId { get; set; }
        public bool c_showInfographicCheckoutAddCard { get; set; }
        public bool c_showInfographicCheckoutCvv { get; set; }
        public bool c_showInfographicPaymentMethods { get; set; }
        public bool c_showInfographicCheckoutBancomer { get; set; }
        public bool c_showInfographicCheckoutSantander { get; set; }
        public bool c_showInfographicPaymentMethodsBancomer { get; set; }
        public bool c_showInfographicPaymentMethodsSantander { get; set; }
        public bool c_dateForActivation { get; set; }
        public string c_tempPostalCode { get; set; }
        public string c_tempStoreId { get; set; }
        public object c_login_apple { get; set; }
        public object c_login_facebook { get; set; }
        public object c_login_google { get; set; }
        public object c_login_linkedin { get; set; }
        public bool c_smsVerified { get; set; }
        public string c_nivelRFM { get; set; }
        public object c_tempStoreIdNoEsp { get; set; }
        public bool c_emailConfirmed { get; set; }
        public object c_tempPostalCodeNoEsp { get; set; }
        public object preferredLocale { get; set; }
        public DateTime birthday { get; set; }
        public List<Address> addresses { get; set; }
        public object errorMessage { get; set; }
        public string defaultStoreId { get; set; }
        public string defaultPostalCode { get; set; }
    }

}