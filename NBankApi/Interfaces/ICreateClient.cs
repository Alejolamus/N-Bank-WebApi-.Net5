using NBankApi.Dtos;

namespace NBankApi.Interfaces
{
    interface ICreateClient
    {
        string createClient(DtosNewClient cliente);
    }
}