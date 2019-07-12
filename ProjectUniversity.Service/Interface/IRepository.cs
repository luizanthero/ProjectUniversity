using System.Collections.Generic;

namespace ProjectUniversity.Service.Interface
{
    public interface IRepository<T>
    {
        void Create(T entity);

        List<T> GetAll();

        T GetById(int? id);

        void Update(T entity);

        void Remove(int id);
    }
}
