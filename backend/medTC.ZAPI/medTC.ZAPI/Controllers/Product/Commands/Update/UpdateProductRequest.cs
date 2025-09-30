using MediatR;

namespace medTC.ZAPI.Controllers.Product.Commands.Update
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public Domain.Models.Product Product { get; set; }
    }
}
