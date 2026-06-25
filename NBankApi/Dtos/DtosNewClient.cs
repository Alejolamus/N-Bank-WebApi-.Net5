using NBankApi.Models.myEnums;

namespace NBankApi.Dtos
{
    public class DtosNewClient
    {
        public string name { get; set; }
        public int idLocation { get; set; }
        public typedocument.typedocu documentType { get; set; }
        public int document { get; set; }
        public string passwarod { get; set; }
        public string email { get; set; }
        public string cellphone { get; set; }
        public string phone { get; set; }
        public DtosNewClient(string Name,
                           int IdLocation,
                           typedocument.typedocu DocumentType,
                           int Document,
                           string Password,
                           string Email,
                           string Cellphone,
                           string Phone)
        {
            name = Name;
            idLocation = IdLocation;
            documentType = DocumentType;
            document = Document;
            passwarod = Password;
            email = Email;
            cellphone = Cellphone;
            phone = Phone;
        }
    }
}