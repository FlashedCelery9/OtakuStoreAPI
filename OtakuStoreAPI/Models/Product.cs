namespace OtakuStoreAPI.Models;

public class Product
{
    public int Id {get;set;}
    public string Title { get; set; } = null!;
    public decimal Price {get;set;}
    public string? Description {get;set;}
    public List<string>? ImagesUrls {get;set;}
    public int Discount { get; set; }
    public string Category { get; set; } = null!;
    public int Amount { get; set; }
    public DateTime PublicatedAt { get; set; }
    
    
}