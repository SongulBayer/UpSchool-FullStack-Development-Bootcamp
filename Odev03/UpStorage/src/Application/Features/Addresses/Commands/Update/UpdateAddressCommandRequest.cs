using Application.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class UpdateAddressCommandRequest: IRequest<Response<int>>
    {
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
    }
}
