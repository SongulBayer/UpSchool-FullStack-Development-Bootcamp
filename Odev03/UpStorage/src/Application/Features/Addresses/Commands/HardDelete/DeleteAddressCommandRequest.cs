using Application.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.HardDelete
{
    public class DeleteAddressCommandRequest:IRequest<Response<Guid>>
    {
        public Guid AdddressId { get; set; }
    }
}
