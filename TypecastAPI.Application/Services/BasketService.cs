using System;
using TypecastAPI.Application.Extensions;
using TypecastAPI.Application.Interfaces;
using TypecastAPI.Domain.Enums;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IRepository<Basket> _basketRepository;

        public BasketService(IArticleRepository articleRepository, IRepository<Basket> basketRepository)
        {
            this._articleRepository = articleRepository;
            this._basketRepository = basketRepository;
        }

        public Basket AddToBasket(String articleType, Guid basketGuid)
        {
            try
            {
                if (articleType == null)
                    throw new ArgumentNullException(nameof(articleType));

                if (basketGuid.Equals(Guid.Empty))
                    throw new ArgumentException(nameof(basketGuid));

                //This is bad but because we do identify article by type and not by guid (interview test require)
                Article article = _articleRepository.GetArticlesByType(articleType).GetEnumerator().Current;

                if (article == null)
                    throw new ArgumentNullException(nameof(article));

                Basket basket = _basketRepository.GetByGuid(basketGuid);

                if (basket == null)
                    throw new ArgumentNullException(nameof(basket));

                BasketArticle basketArticle = new BasketArticle(article);

                basket.InsertArticle(basketArticle);

                return basket;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Basket CreateBasket()
        {
            try
            {
                Basket basket = new Basket();

                _basketRepository.Insert(basket);

                return basket;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

    }
}
