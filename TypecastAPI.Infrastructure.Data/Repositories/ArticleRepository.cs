using System;
using System.Collections.Generic;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Infrastructure.Data.Repositories
{
    public class ArticleRepository: Repository<Article>, IArticleRepository
    {
		public IEnumerable<Article> GetAllArticles()
		{
            try
            {
                return this.List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEnumerable<Article> GetArticlesByType(string articleType)
        {
            try
            {
                if (String.IsNullOrEmpty(articleType))
                    throw new ArgumentNullException(nameof(articleType));

                return this.List.FindAll(x => x.Type == articleType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
