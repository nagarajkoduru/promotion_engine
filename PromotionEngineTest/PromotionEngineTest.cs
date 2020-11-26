using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PromotionEngine;
using System.Linq;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void TestMethod()
        {
            int _totalExpResult1 = 100;
            int _totalExpResult2 = 370;
            int _totalExpResult3 = 280;
            Dictionary<int, int> result = new Dictionary<int, int>();
            //create list of promotions
            //we need to add information about Product's count
            Dictionary<String, int> dictA = new Dictionary<String, int>();
            dictA.Add("A", 3);
            Dictionary<String, int> dictB = new Dictionary<String, int>();
            dictB.Add("B", 2);
            Dictionary<String, int> dictC = new Dictionary<String, int>();
            dictC.Add("C", 1);
            dictC.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, dictA, 130),
                new Promotion(2, dictB, 45),
                new Promotion(3, dictC, 30)
            };

            //create orders
            List<Order> orders = new List<Order>();
            orders.AddRange(new Order[]
            {
                new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") }),
                new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("C") }),
                new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("C"), new Product("D") })
            });

            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => PromotionComputingHelper.GetTotal(ord, promo))
                    .ToList();
                //decimal origprice = ord.Products.Sum(x=>x.Price);
                decimal promoprice = promoprices.Sum();
                result.Add(ord.Order_Id, Convert.ToInt32(promoprice));
                Console.WriteLine($"OrderID: {ord.Order_Id} => Final price: {promoprice.ToString("0.00")}");
            }
            Assert.AreEqual(_totalExpResult1, result[1]);
            Assert.AreEqual(_totalExpResult2, result[2]);
            Assert.AreEqual(_totalExpResult3, result[3]);
        }
    }
}
