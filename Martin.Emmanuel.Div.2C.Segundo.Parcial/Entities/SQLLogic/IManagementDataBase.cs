using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SQLLogic
{
    public interface IManagementDataBase<T>
    {
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);

    }
}
