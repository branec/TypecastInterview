using System;
namespace TypecastAPI.Domain.Models
{
    public class BasketArticle : Article
    {
        public bool AppliedDiscount { get; set; }

        public BasketArticle()
        {
            this.AppliedDiscount = false;
        }

        public BasketArticle(Article article) {

            this.Guid = article.Guid;
            this.Type = article.Type;
            this.Price = article.Price;
            this.AppliedDiscount = false;

        }

    }
}
