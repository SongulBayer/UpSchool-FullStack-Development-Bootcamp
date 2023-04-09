
using MediatR;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGelALLQueries:IRequest<List<CityGetAllDto>>
    {
        public int CountryId { get; set; }
        public bool? IsDeleted { get; set; }
        public CityGelALLQueries(int countryId,bool? isDeleted)
        {
            CountryId = countryId;
            IsDeleted=isDeleted;
        }
    }
    
}
