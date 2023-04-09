using MediatR;

namespace Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAllAddressQueryRequest:IRequest<GetByIdAllAddressQueryResponse>
    {
       public Guid  Id { get; set; }
    }
}
