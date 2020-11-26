using System.Collections.Generic;

public class Order
{
    public int Order_Id  { get; set; }
    public List<Product> Products { get; set; }

    public Order(int orderId, List<Product> products)
    {
        this.Order_Id = orderId;
        this.Products = products;
    }
}