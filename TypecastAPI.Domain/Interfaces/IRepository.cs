using System;
using System.Collections.Generic;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Domain.Interfaces
{
    public partial interface IRepository<T> where T : BaseModel
    {

        T GetByGuid(Guid guid);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

    }
}
