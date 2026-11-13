namespace OtakuStoreAPI.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = null!;
    public int ProductId { get; set; }
    public int Amount { get; set; }

    public AppUser User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}