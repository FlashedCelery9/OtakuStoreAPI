namespace OtakuStoreAPI.DTO_s;

public class ProductDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<string>? ImagesUrls { get; set; }
    public string Category { get; set; } = null!;
    public int Discount { get; set; }
    public int Amount { get; set; }
    
}