using System;
using System.Collections.Generic;
using System.Linq;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private static List<T> _list;

        protected virtual List<T> List
        {
            get
            {
                if (_list == null)
                    _list = _list = new List<T>();
                return _list;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                this.List.Remove(entity);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    this.List.Remove(entity);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T GetByGuid(Guid guid)
        {
            try
            {
                if (Guid.Empty.Equals(guid))
                    throw new ArgumentNullException(nameof(guid));

                return this.List.Find(x => x.Guid == guid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                this.List.Add(entity);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    this.List.Add(entity);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                T foundedEntity = this.List.Find(x => x.Guid == entity.Guid);

                if(foundedEntity == null)
                    throw new ArgumentNullException($"There is not finded entity type: {nameof(entity)} with Guid: {entity.Guid}");

                foundedEntity = entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                {
                    T foundedEntity = this.List.Find(x => x.Guid == entity.Guid);

                    if (foundedEntity == null)
                        throw new ArgumentNullException($"There is not finded entity type: {nameof(entity)} with Guid: {entity.Guid}");

                    foundedEntity = entity;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
