using System.ComponentModel.DataAnnotations;

namespace Unicv.Eventos.Api.Models.Request;

public class StateRequest
{
    public string Name { get; set; }

    public string Acronym { get; set; }
}
