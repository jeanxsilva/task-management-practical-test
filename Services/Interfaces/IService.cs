using System.Data;
using System.Data.Common;

namespace TaskManager
{
    public interface IService<T, D>
        where T : class
        where D : IDbConnection
    {
        public void Insert(T t);
        public void Update(T t);
        public bool Delete(int id);
        public T GetById(int id);
        public List<T> GetAll();
    }
}
