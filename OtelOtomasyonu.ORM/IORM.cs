using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM
{
    public interface IORM<T> where T:class
    {
        DataTable Select();
        object InsertScalar(T entity);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Updated(T entity);
    }
}
