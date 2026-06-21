using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Delete(int id);
        bool Update(T entity);
        bool Add(T entity);
    }
}
