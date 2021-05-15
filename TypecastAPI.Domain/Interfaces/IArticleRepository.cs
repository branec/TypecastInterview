using System;
using System.Collections.Generic;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetArticlesByType(string articleType);

        IEnumerable<Article> GetAllArticles();

    }
}
