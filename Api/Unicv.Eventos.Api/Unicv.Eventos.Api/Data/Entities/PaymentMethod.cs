using System.ComponentModel.DataAnnotations.Schema;

namespace Unicv.Eventos.Api.Data.Entities;

[Table("ev_payment_methods")]
public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
}
