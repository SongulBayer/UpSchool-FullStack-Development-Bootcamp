using Application.Common;
using Application.Common.Interfaces;
using Application.Features.Addresses.Commands.Add;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, Response<int>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.Where(a => a.Id == request.AddressId).FirstOrDefaultAsync();
            if (address == null)
            {
                return default;
            }
            else
            {
                address.AddressLine1 = request.AddressLine1;
                address.AddressLine2 = request.AddressLine2;
                address.Name=request.Name;
                address.District = request.District;
                address.PostCode=request.PostCode;
                    
            }
             _context.Addresses.Update(address);
            await _context.SaveChangesAsync(cancellationToken);
            return new Response<int>();

        }
    }
}
 