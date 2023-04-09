using Application.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Add
{
    public class AddAddressCommandRequest: IRequest<AddAddressCommandResponse<int>>
    {
        public string  Name { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

    }
}
//Mediatr kütüphanesi sayesinde hangi sınıfın request sınıfı olduğunu ve hangi 
//sınıfın response olarak döndürüleceğini biliyoruz