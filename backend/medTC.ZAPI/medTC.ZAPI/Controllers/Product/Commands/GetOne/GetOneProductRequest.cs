using MediatR;

namespace medTC.ZAPI.Controllers.Product.Commands.GetOne
{
    public class GetOneProductRequest : IRequest<GetOneProductResponse>
    {
        public long Id { get; set; }
    }
}
