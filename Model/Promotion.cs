using System.Collections.Generic;

public class Promotion
{
    public int Promotion_Id  { get; set; }
    public Dictionary<string, int> Product_Info { get; set; }
    public decimal Promo_Price  { get; set; }

    public Promotion(int promotionId, Dictionary<string, int> productInfo, decimal promoPrice)
    {
        this.Promotion_Id = promotionId;
        this.Product_Info = productInfo;
        this.Promo_Price = promoPrice;
    }
}