using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.DataAccess
{
    public interface IRepository<T>
    {
        void Insert(T entity);
    }
}
