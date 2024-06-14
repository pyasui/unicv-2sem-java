using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Unicv.Eventos.Api.Data.Context;
using Unicv.Eventos.Api.Data.Entities;
using Unicv.Eventos.Api.Models.Request;

namespace Unicv.Eventos.Api.Controllers;

[ApiController]
[Tags("Usuários")]
[Route("api/usuarios")]
public class UserController : ControllerBase
{
    private readonly DataContext _db;

    public UserController(IConfiguration configuration)
    {
        _db = new DataContext(configuration);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _db.DbUsers.ToList();
        return Ok(list);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _db.DbUsers.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post(UserRequest request)
    {
        if (request == null)
            return BadRequest();

        // campos obrigatórios
        if (string.IsNullOrWhiteSpace(request.Name))
            return StatusCode(422, "O nome do estado é obrigatório");

        if (string.IsNullOrWhiteSpace(request.Email))
            return StatusCode(422, "O campo e-mail é obrigatório");

        if (string.IsNullOrWhiteSpace(request.Cpf))
            return StatusCode(422, "O campo CPF é obrigatório");

        // validações
        if (_db.DbUsers.Any(x => x.Email == request.Email))
            return BadRequest("Já existe um usuário cadastrado com este e-mail");

        if (_db.DbUsers.Any(x => x.Cpf == request.Cpf))
            return BadRequest("Já existe um usuário cadastrado com este CPF");

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Cpf = request.Cpf
        };

        _db.DbUsers.Add(user);
        _db.SaveChanges();

        return Ok();
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] UserRequest request)
    {
        if (request == null)
            return BadRequest();

        // campos obrigatórios
        if (string.IsNullOrWhiteSpace(request.Name))
            return StatusCode(422, "O nome do estado é obrigatório");

        if (string.IsNullOrWhiteSpace(request.Email))
            return StatusCode(422, "O campo e-mail é obrigatório");

        if (string.IsNullOrWhiteSpace(request.Cpf))
            return StatusCode(422, "O campo CPF é obrigatório");

        // validações
        if (_db.DbUsers.Any(x => x.Email == request.Email && x.Id != id))
            return BadRequest("Já existe um usuário cadastrado com este e-mail");

        if (_db.DbUsers.Any(x => x.Cpf == request.Cpf && x.Id != id))
            return BadRequest("Já existe um usuário cadastrado com este CPF");

        var entity = _db.DbUsers.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        entity.Name = request.Name;
        entity.Email = request.Email;
        entity.Cpf = request.Cpf;

        _db.DbUsers.Update(entity);
        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = _db.DbUsers.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        _db.DbUsers.Remove(entity);
        _db.SaveChanges();

        return Ok();
    }
}
