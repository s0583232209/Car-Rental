namespace DAL.Interfaces;

public interface IRepository<T>
{
    List<T> GetAll();
    T GetById(int id);
    T Add(T entity);
    bool Update(T entity);
    bool Delete(int id);
}