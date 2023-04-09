using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, List<GetAllAddressQueryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAddressQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllAddressQueryResponse>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var dbQuery = _context.Addresses.AsQueryable();

            dbQuery = dbQuery.Where(x => x.CountryId == request.UserId);

            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

            dbQuery = dbQuery.Include(x => x.Country);
            dbQuery = dbQuery.Include(x => x.City);

            var addresses = await dbQuery.ToListAsync(cancellationToken);

            var addressDtos = MapAddressesToGetAllDtos(addresses);

            return addressDtos.ToList();
        }

        private IEnumerable<GetAllAddressQueryResponse> MapAddressesToGetAllDtos(List<Address> addresses)
        {
            List<GetAllAddressQueryResponse> addressGetAllDtos = new List<GetAllAddressQueryResponse>();

            foreach (var address in addresses)
            {

                yield return new GetAllAddressQueryResponse()
                {
                    Id = address.Id,
                    CountryId = address.CountryId,
                    CountryName = address.Country.Name,
                    Name = address.Name,
                    IsDeleted = address.IsDeleted,
                    CityId=address.CityId,
                    CityName=address.City.Name,
                    District=address.District,
                    PostCode=address.PostCode,
                    AddressLine1=address.AddressLine1,
                    AddressLine2=address.AddressLine2,
                    AddressType=address.AdressType,
                    UserId=address.UserId,

                };
            }
        }
    }
}
