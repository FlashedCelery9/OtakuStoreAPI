namespace OtakuStoreAPI.DTO_s;

public class OrderDto
{
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }
    public int Amount { get; set; }
}