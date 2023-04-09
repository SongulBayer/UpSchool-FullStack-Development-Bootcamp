using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAllAddressQueryHandler : IRequestHandler<GetByIdAllAddressQueryRequest, GetByIdAllAddressQueryResponse>
    {
        private readonly IApplicationDbContext _context;
        public async Task<GetByIdAllAddressQueryResponse> Handle(GetByIdAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
         var adress= await _context.Addresses.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            return new()
            {
                Name = adress.Name,
                CountryName=adress.Country.Name,
                CityName=adress.City.Name,
                District=adress.District,
                PostCode=adress.PostCode,
                AddressLine1=adress.AddressLine1,
                AddressLine2 = adress.AddressLine2,
                AddressType=adress.AdressType,
                IsDeleted=adress.IsDeleted,
            };
                
        }
    }
}
