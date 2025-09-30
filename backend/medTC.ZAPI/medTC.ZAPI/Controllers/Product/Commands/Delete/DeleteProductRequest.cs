using MediatR;

namespace medTC.ZAPI.Controllers.Product.Commands.Delete
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public long Id { get; set; }
    }
}
