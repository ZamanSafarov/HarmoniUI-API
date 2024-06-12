using Harmoni.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Harmoni.Core.RepAbstracts
{
    public interface IGenericRepository<T>where T :BaseEntity,new()
    {
        int Commit();

        void Add(T entity);
        void SoftDelete(T entity);
        void HardDelete(T entity);

        T Get(Func<T, bool>? func = null, params string[]? includes);
        ICollection<T> GetAll(Func<T, bool>? func = null, params string[]? includes);
	}
}
