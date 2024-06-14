using System.ComponentModel.DataAnnotations.Schema;

namespace Unicv.Eventos.Api.Data.Entities;

[Table("ev_users")]
public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Cpf { get; set; }
}
