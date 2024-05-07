using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    //Repositório genérico para operações que devem ser implementadas
    public interface IRepository<T> where T : class
    {
        //T - Category or Product etc...
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
