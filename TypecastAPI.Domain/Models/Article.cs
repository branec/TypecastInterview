using System;
using System.ComponentModel.DataAnnotations;

namespace TypecastAPI.Domain.Models
{
    public class Article: BaseModel
    {
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public Article()
        {
            this.Type = new String('0', 32);
            this.Price = 0.0M;
        }

        public Article(string type, decimal price)
        {
            this.Type = type;
            this.Price = price;
        }


    }
}
