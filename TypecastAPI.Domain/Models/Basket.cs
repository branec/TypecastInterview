using System;
using System.Collections.Generic;
using TypecastAPI.Domain.Enums;

namespace TypecastAPI.Domain.Models
{
    public class Basket : BaseModel
    {
        public List<BasketArticle> Articles { get; set; }
        public List<Discount> UnusedDiscounts { get; set; }

        public Decimal Total
        { get {
                Decimal total = 0m;
                foreach (var article in Articles)
                {
                    total += article.Price;
                }
                return total;
        }     }

        public Basket()
        {
            this.Articles = new List<BasketArticle>();
            this.UnusedDiscounts = new List<Discount>();
        }
    }
}
