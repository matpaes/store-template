using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.api.UseCases.Product.Delete;
using store.api.UseCases.Product.Get;
using store.api.UseCases.Product.List;
using store.api.UseCases.Product.Update;
using Swashbuckle.AspNetCore.Annotations;

namespace store.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IGetProductUseCase _getProductUseCase;
        private readonly IListProductUseCase _listProductsUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;

        public ProductController(
            ICreateProductUseCase createProductUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IGetProductUseCase getProductUseCase,
            IListProductUseCase listProductsUseCase,
            IDeleteProductUseCase deleteProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _updateProductUseCase = updateProductUseCase;
            _getProductUseCase = getProductUseCase;
            _listProductsUseCase = listProductsUseCase;
            _deleteProductUseCase = deleteProductUseCase;
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="input">Dados do produto a ser criado.</param>
        /// <returns>Detalhes do produto criado.</returns>
        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(typeof(CreateProductOutput), 201)]
        [ProducesResponseType(400)]
        [SwaggerOperation(
            Summary = "Cria um novo produto",
            Description = "Este endpoint cria um novo produto no sistema. Todos os campos são obrigatórios."
        )]
        public async Task<IActionResult> Create([FromBody] CreateProductInput input)
        {
            try
            {
                var result = await _createProductUseCase.Execute(input);
                return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="input">Dados atualizados do produto.</param>
        /// <returns>Detalhes do produto atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateProductOutput), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [SwaggerOperation(
            Summary = "Atualiza um produto",
            Description = "Este endpoint atualiza os detalhes de um produto existente pelo ID."
        )]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductInput input)
        {
            input.Id = id;
            try
            {
                var result = await _updateProductUseCase.ExecuteAsync(input);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Obtém os detalhes de um produto.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Detalhes do produto.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetProductOutput), 200)]
        [ProducesResponseType(404)]
        [SwaggerOperation(
            Summary = "Obtém detalhes de um produto",
            Description = "Este endpoint retorna os detalhes de um produto específico pelo ID."
        )]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _getProductUseCase.ExecuteAsync(new GetProductInput(id));
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Lista todos os produtos.
        /// </summary>
        /// <returns>Uma lista de produtos.</returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ListProductOutput>), 200)]
        [SwaggerOperation(
            Summary = "Lista todos os produtos",
            Description = "Este endpoint retorna uma lista de todos os produtos cadastrados."
        )]
        public async Task<IActionResult> ListProducts()
        {
            var result = await _listProductsUseCase.ExecuteAsync();

            if (result.Any())
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// Remove um produto.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>Confirmação da remoção.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteProductOutput), 200)]
        [ProducesResponseType(404)]
        [SwaggerOperation(
            Summary = "Remove um produto",
            Description = "Este endpoint remove um produto específico pelo ID."
        )]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _deleteProductUseCase.ExecuteAsync(new DeleteProductInput(id));
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
