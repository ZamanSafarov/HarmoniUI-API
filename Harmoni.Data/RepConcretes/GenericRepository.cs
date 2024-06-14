using Harmoni.Core.Entities;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Data.RepConcretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext db)
        {
            _appDbContext = db;
        }
        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }
        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }
        public void HardDelete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
        }
        public T Get(Func<T, bool>? func = null, params string[]? includes)
        {
            var entity = _appDbContext.Set<T>().AsQueryable();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    entity = entity.Include(item);
                }
            }
            return func == null ?
                  entity.FirstOrDefault() :
                   entity.Where(func).FirstOrDefault();
        }

        public ICollection<T> GetAll(Func<T, bool>? func = null, params string[]? includes)
        {
            var entity = _appDbContext.Set<T>().AsQueryable();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    entity = entity.Include(item);
                }
            }
            return func == null ?
               entity.ToList() :
               entity.Where(func).ToList();
        }
	
	}
}
