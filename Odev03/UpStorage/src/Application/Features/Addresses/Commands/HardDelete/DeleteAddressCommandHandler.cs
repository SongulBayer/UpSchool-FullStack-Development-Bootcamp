using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Addresses.Commands.HardDelete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, Response<Guid>>
    {

        private readonly IApplicationDbContext _context;

        public DeleteAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            
            var address = await _context.Addresses.Where(a => a.Id == request.AdddressId).FirstOrDefaultAsync();
             _context.Addresses.Remove(address);
            return new Response<Guid>($"address \"{address.Name}\" removed");

        }
    }
}
