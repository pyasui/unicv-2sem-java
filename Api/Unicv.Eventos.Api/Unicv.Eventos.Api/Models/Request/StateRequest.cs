using System.ComponentModel.DataAnnotations;

namespace Unicv.Eventos.Api.Models.Request;

public class StateRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Acronym { get; set; }
}
