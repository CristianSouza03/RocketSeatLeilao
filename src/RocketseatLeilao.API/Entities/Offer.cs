using System.Security.Cryptography.X509Certificates;

namespace RocketseatLeilao.API.Entities;

public class Offer
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Price { get; set; } 
    public int ItemId { get; set; }
    public int UserId { get; set; }

}
