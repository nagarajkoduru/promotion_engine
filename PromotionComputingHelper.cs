using System.Linq;

namespace PromotionEngine
{
    public static class PromotionComputingHelper
    {
        //returns Promotion_Id and count of promotions
        public static decimal GetTotal(Order order, Promotion promotion)
        {
            decimal totalPrice = 0M;
            //get count of promoted products in an order
            var countOfPP = order.Products
                .GroupBy(a => a.Id)
                .Where(grop => promotion.Product_Info.Any(y => grop.Key == y.Key && grop.Count() >= y.Value))
                .Select(grop => grop.Count())
                .Sum();

            //get count of promoted products from promotion
            int promotedP = promotion.Product_Info.Sum(kvp => kvp.Value);
            while (countOfPP >= promotedP)
            {
                totalPrice += promotion.Promo_Price;
                countOfPP -= promotedP;
            }

            if (totalPrice != 0M)
            {
                totalPrice = totalPrice + countOfPP * new Product(promotion.Product_Info.Keys.FirstOrDefault()).Price;
            }
            else
            {
                totalPrice = totalPrice + new Product(promotion.Product_Info.Keys.FirstOrDefault()).Price;
            }

            return totalPrice;
        }
    }
}