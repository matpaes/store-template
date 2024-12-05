using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace store.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CreateProductController : ControllerBase
        {
            private readonly CreateProductUseCase _createProductUseCase;

            public CreateProductController(CreateProductUseCase createProductUseCase)
            {
                _createProductUseCase = createProductUseCase;
            }

            /// <summary>
            /// Cria um novo produto.
            /// </summary>
            /// <param name="input">Dados do produto a ser criado.</param>
            /// <returns>Detalhes do produto criado.</returns>
            /// <response code="201">Produto criado com sucesso.</response>
            /// <response code="400">Se os dados de entrada forem inválidos.</response>
            [HttpPost]
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

                    // Retorna o produto criado com código HTTP 201 (Created)
                    return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
                }
                catch (ArgumentException ex)
                {
                    // Se houver erro na validação dos dados de entrada
                    return BadRequest(new { message = ex.Message });
                }
            }
        }
}
