using DesafioTotvs.Application.DTOs;
using DesafioTotvs.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTotvs.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductAppService productAppService, ILogger<ProductsController> logger)
        {
            _productAppService = productAppService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _productAppService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productAppService.GetByIdAsync(id, cancellationToken);
            if (product is null)
                return NotFound(new { message = "Produto não encontrado." });

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateUpdateDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productAppService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] ProductCreateUpdateDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _productAppService.UpdateAsync(id, dto, cancellationToken);
            if (updated is null)
                return NotFound(new { message = "Produto não encontrado." });

            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _productAppService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound(new { message = "Produto não encontrado." });

            return NoContent();
        }
    }

}
