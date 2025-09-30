using MediatR;
using medTC.ZAPI.Controllers.Product.Commands.Delete;
using medTC.ZAPI.Controllers.Product.Commands.GetAll;
using medTC.ZAPI.Controllers.Product.Commands.GetOne;
using medTC.ZAPI.Controllers.Product.Commands.Insert;
using medTC.ZAPI.Controllers.Product.Commands.Update;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace medTC.ZAPI.Controllers.Product
{
    [Route("api/product")]
    public class ProductController : CustomControllerBase
    {
        private readonly IMediator _med;
        public ProductController(IMediator med)
        {
            _med = med;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _med.Send(new GetAllProductRequest());
            return Ok(result);
        }

        [HttpGet("getone/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _med.Send(new GetOneProductRequest { Id = id });
            return Ok(result);
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertProductRequest request)
        {
            var result = await _med.Send(request);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            var result = await _med.Send(request);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _med.Send(new DeleteProductRequest { Id = id });
            return Ok(result);
        }
    }
}

