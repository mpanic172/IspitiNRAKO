using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspitiNRAKO.Interfaces
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int? Id);
        void Save();
    }
}
