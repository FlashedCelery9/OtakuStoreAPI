namespace OtakuStoreAPI.DTO_s;

public class ShopProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; } 
    public int Discount { get; set; }
    public int Amount { get; set; }
    public string? ImgUrl { get; set; } //Img[0] 
}