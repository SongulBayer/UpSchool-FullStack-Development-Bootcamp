using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.Add
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandRequest, AddAddressCommandResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddAddressCommandResponse<int>> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
        {

            var address = new Address
            {
                AddressLine1 = request.AddressLine1,
                Name = request.Name,
                District = request.District,
                PostCode = request.PostCode,
          
            };

            await _context.Addresses.AddAsync(address,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new AddAddressCommandResponse<int>();

        }
    }
}
//handler sınıfı gelen request sınıfına karşılık bir response sınıfı döndürecek