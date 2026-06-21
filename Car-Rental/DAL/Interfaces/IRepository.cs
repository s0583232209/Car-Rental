using Infrastructure.DTOs;
namespace DAL.Interfaces;

/// <summary>
/// ממשק גנרי – T הוא ה-Entity של הטבלה
/// כל ה-Repositories מממשים ממשק זה
/// </summary>
public interface IRepository<T>
{
    List<T> GetAll();
    T GetById(int id);
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(int id);
}