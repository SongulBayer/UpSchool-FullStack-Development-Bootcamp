using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Commands.Add
{
    public class CityAddCommandHandler : IRequestHandler<CityAndCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CityAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(CityAndCommand request, CancellationToken cancellationToken)
        {

            if (!await _applicationDbContext.Countries.AnyAsync(x=>x.Id==request.CountryId,cancellationToken))
            {
                throw new  ArgumentNullException(nameof(request.CountryId));
            }  
            if (await _applicationDbContext.Countries.AnyAsync(x=>x.Name.ToLower()==request.Name.ToLower(),cancellationToken))
            {
                throw new  ArgumentNullException(nameof(request.Name));
            }
            var city = new City
            {
                Name=request.Name,
                CountryId=request.CountryId,
                Latitude=request.Latitude,
                Longitude=request.Longitude,
                CreatedOn=DateTimeOffset.Now,
                CreatedByUserId=null,
                IsDeleted=false,
            };
            await _applicationDbContext.Cities.AddAsync(city,cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<int>($"new city \"{city.Name}\" added", city.Id);
        }
    }
}
