using System;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Application.Interfaces
{
    public interface IBasketService
    {
        Basket AddToBasket(String articleType, Guid basketGuid);

        Basket CreateBasket();
    }
}
