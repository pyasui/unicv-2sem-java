using Microsoft.AspNetCore.Mvc;
using Unicv.Eventos.Api.Data.Context;
using Unicv.Eventos.Api.Data.Entities;
using Unicv.Eventos.Api.Models.Request;

namespace Unicv.Eventos.Api.Controllers;

[ApiController]
[Tags("Estados")]
[Route("api/estados")]
public class StatesController : ControllerBase
{
    private readonly DataContext _db;

    public StatesController(IConfiguration configuration)
    {
        _db = new DataContext(configuration);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _db.DbStates.ToList();
        return Ok(list);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var state = _db.DbStates.FirstOrDefault(x => x.Id == id);
        if (state == null)
            return NotFound();

        return Ok(state);
    }

    [HttpPost]
    public IActionResult Post(StateRequest request)
    {
        if (request == null)
            return BadRequest();

        var entity = new State
        {
            Name = request.Name,
            Acronym = request.Acronym,
        };

        _db.DbStates.Add(entity);
        _db.SaveChanges();

        return Ok();
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] StateRequest request)
    {
        if (request == null)
            return BadRequest();

        var entity = _db.DbStates.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        entity.Name = request.Name;
        entity.Acronym = request.Acronym;

        _db.DbStates.Update(entity);
        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = _db.DbStates.FirstOrDefault(x => x.Id == id);

        if (entity == null)
            return NotFound();

        _db.DbStates.Remove(entity);
        _db.SaveChanges();

        return Ok();
    }
}
