using System;
using System.Collections.Generic;
using System.Linq;
using TypecastAPI.Application.Interfaces;
using TypecastAPI.Application.ViewModels;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Application.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public Article AddArticle(Article article)
        {
            try
            {
                if (article == null)
                    throw new ArgumentNullException(nameof(article));

                _articleRepository.Insert(article);
                return article;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
