using System;
using System.Collections.Generic;
using TypecastAPI.Application.ViewModels;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Application.Interfaces
{
    public interface IArticleService
    {
        Article AddArticle(Article article);

	}
}
