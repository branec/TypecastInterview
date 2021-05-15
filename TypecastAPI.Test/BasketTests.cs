using System;
using Moq;
using TypecastAPI.Application.Interfaces;
using TypecastAPI.Application.Services;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Domain.Models;
using TypecastAPI.Application.Extensions;
using Xunit;

namespace TypecastAPI.Test
{
    public class BasketTests
    {
        Article butter;
        Article milk;
        Article bread;

        public BasketTests() {

            butter = new Article("Butter", 0.80m);
            milk = new Article("Milk", 1.15m);
            bread = new Article("Bread", 1.0m);

        }


        [Fact]
        public void AddToBasket1Bread1Milk1ButterTest()
        {
            Basket basket = new Basket();

            basket.InsertArticle(new BasketArticle(butter));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(bread));

            Assert.Equal(2.95m, basket.Total);

        }

        [Fact]
        public void AddToBasket2Breads2ButtersTest()
        {
            Basket basket = new Basket();

            basket.InsertArticle(new BasketArticle(butter));
            basket.InsertArticle(new BasketArticle(butter));
            basket.InsertArticle(new BasketArticle(bread));
            basket.InsertArticle(new BasketArticle(bread));

            Assert.Equal(3.10m, basket.Total);

        }

        [Fact]
        public void AddToBasket4MilksTest()
        {
            Basket basket = new Basket();

            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));

            Assert.Equal(3.45m, basket.Total);

        }

        [Fact]
        public void AddToBasket2Butters1Bread8MilksTest()
        {
            Basket basket = new Basket();

            basket.InsertArticle(new BasketArticle(butter));
            basket.InsertArticle(new BasketArticle(butter));
            basket.InsertArticle(new BasketArticle(bread));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));
            basket.InsertArticle(new BasketArticle(milk));

            Assert.Equal(9.00m, basket.Total);

        }
    }
}
