using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unicv.Eventos.Api.Data.Context;

namespace Unicv.Eventos.Api.Controllers;

[ApiController]
[Route("api/metodos-pagamento")]
[Tags("Métodos de Pagamento")]
public class PaymentMethodController : ControllerBase
{
    private readonly DataContext _db;

    public PaymentMethodController(IConfiguration configuration)
    {
        _db = new DataContext(configuration);
    }

    #region Get
    /// <summary>
    /// Retorna todas os métodos de pagamentos
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Retorna a lista de métodos de pagamentos</response>
    [HttpGet]
    public IActionResult Get()
    {
        var accounts = _db.DbPaymentMethods.ToList();
        return Ok(accounts);
    }
    #endregion

    #region GetById
    /// <summary>
    /// Retornar um método de pagamento de acordo com o Id
    /// </summary>
    /// <param name="id">Id do método de pagamento</param>
    /// <returns></returns>
    /// <response code="200">Retorna o método de pagamento desejado</response>
    /// <response code="404">Método de pagamento não encontrada</response>
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var method = _db.DbPaymentMethods.FirstOrDefault(x => x.Id == id);
        if (method == null)
            return NotFound();

        return Ok(method);
    }
    #endregion
}
