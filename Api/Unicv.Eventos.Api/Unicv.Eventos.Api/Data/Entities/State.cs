using System.ComponentModel.DataAnnotations.Schema;

namespace Unicv.Eventos.Api.Data.Entities;

[Table("ev_states")]
public class State
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Acronym { get; set; }
}
