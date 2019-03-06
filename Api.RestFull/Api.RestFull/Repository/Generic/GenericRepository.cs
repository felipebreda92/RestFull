using Api.RestFull.Model.Base;
using Api.RestFull.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.RestFull.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly Context _context;

        private DbSet<T> dataset;

        public GenericRepository(Context context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public bool Delete(int id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                    dataset.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result != null;
        }

        public bool Exist(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exist(item.Id))
                return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
