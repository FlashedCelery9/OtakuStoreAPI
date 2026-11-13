using OtakuStoreAPI.Models;

namespace OtakuStoreAPI.DTO_s;

public class CartDto
{
    public List<Order> Orders { get; set; } = new List<Order>([]);
    
}