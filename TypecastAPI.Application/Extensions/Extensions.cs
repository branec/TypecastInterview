using System;
using TypecastAPI.Domain.Enums;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Application.Extensions
{
    public static class Extensions
    {
        public static void InsertArticle(this Basket basket, BasketArticle basketArticle)
        {
            switch (basketArticle.Type)
            {
                case "Butter":
                    if ((basket.Articles.FindAll(x => x.Type == "Butter").Count + 1) % 2 == 0)
                    {
                        BasketArticle bread = basket.Articles.Find(x => x.Type == "Bread" && x.AppliedDiscount == false);
                        if (bread != null)
                        {
                            bread.AppliedDiscount = true;
                            bread.Price = bread.Price / 2;
                        }
                        else
                        {
                            basket.UnusedDiscounts.Add(Discount.TwoButter);
                        }
                    }
                    basket.Articles.Add(basketArticle);
                    break;
                case "Milk":
                    if ((basket.Articles.FindAll(x => x.Type == "Milk").Count + 1) % 4 == 0)
                    {
                        basketArticle.AppliedDiscount = true;
                        basketArticle.Price = 0;
                    }
                    basket.Articles.Add(basketArticle);
                    break;
                case "Bread":
                    if (basket.UnusedDiscounts.FindIndex(x => x.Equals(Discount.TwoButter)) >= 0)
                    {
                        basketArticle.AppliedDiscount = true;
                        basketArticle.Price = basketArticle.Price / 2;
                        basket.UnusedDiscounts.Remove(Discount.TwoButter);
                    }

                    basket.Articles.Add(basketArticle);
                    break;
                default:
                    basket.Articles.Add(basketArticle);
                    break;
            }
        }
    }
}
