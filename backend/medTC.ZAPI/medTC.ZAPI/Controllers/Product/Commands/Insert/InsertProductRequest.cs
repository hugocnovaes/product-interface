using MediatR;

namespace medTC.ZAPI.Controllers.Product.Commands.Insert
{
    public class InsertProductRequest : IRequest<InsertProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
