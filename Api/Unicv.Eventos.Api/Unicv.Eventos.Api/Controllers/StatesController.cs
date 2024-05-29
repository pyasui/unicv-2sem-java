using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unicv.Eventos.Api.Data.Context;

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
}
