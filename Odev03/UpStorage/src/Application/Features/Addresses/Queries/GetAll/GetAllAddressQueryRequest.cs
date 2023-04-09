using MediatR;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressQueryRequest: IRequest<List<GetAllAddressQueryResponse>>
    {
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public GetAllAddressQueryRequest(int userId, bool? isDeleted)
        {
            UserId = userId;
            IsDeleted = isDeleted;
        }
    }
}
