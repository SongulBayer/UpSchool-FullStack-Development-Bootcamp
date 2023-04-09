using Application.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressDeleteCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
