using Domain.Enums;

namespace Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAllAddressQueryResponse
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public AdressType AddressType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
