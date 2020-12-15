using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Domain.Repository
{
    public interface IBaseRepository<T> where T: class
    {
        Task Save(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}