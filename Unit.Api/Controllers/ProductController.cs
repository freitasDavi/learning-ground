

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Unit.Core.Dtos.Products;
using Unit.Core.Interfaces.Products;

namespace Unit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _service = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
        {
            try
            {

                var result = await _service.GetByIdAsync(id);

                if (result is null)
                    return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductDto request)
        {
            return Ok(await _service.AddAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto request)
        {
            try
            {
                await _service.UpdateAsync(id, request);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct([FromRoute] int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}