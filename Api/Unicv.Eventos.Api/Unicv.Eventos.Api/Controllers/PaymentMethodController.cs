using Microsoft.AspNetCore.Mvc;
using Unicv.Eventos.Api.Data.Context;
using Unicv.Eventos.Api.Data.Entities;
using Unicv.Eventos.Api.Models.Request;

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

    [HttpPost]
    public IActionResult Post(PaymentMethodRequest request)
    {
        if (request == null)
            return BadRequest();

        // campos obrigatórios
        if (string.IsNullOrWhiteSpace(request.Name))
            return StatusCode(422, "O nome do método de pagamento é obrigatório");

        // validações
        if (_db.DbPaymentMethods.Any(x => x.Name == request.Name))
            return BadRequest("Já existe um método de pagamento cadastrado com este nome");

        var entity = new PaymentMethod
        {
            Name = request.Name,
        };

        _db.DbPaymentMethods.Add(entity);
        _db.SaveChanges();

        return Ok();
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] PaymentMethodRequest request)
    {
        if (request == null)
            return BadRequest();

        // campos obrigatórios
        if (string.IsNullOrWhiteSpace(request.Name))
            return StatusCode(422, "O nome do método de pagamento é obrigatório");

        // validações
        if (_db.DbPaymentMethods.Any(x => x.Name == request.Name && x.Id != id))
            return BadRequest("Já existe um método de pagamento cadastrado com este nome");

        var entity = _db.DbPaymentMethods.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        entity.Name = request.Name;

        _db.DbPaymentMethods.Update(entity);
        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = _db.DbPaymentMethods.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        _db.DbPaymentMethods.Remove(entity);
        _db.SaveChanges();

        return Ok();
    }
}
