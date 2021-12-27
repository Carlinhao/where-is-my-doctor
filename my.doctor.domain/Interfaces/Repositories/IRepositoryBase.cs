using System.Collections.Generic;
using System.Threading.Tasks;

namespace my.doctor.domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TSource> where TSource : class
    {
        Task<IEnumerable<TSource>> GetAll();
        Task<TSource> GetById(object id);
        Task Insert(TSource obj);
        Task Update(TSource obj);
        Task Delete(object id);
    }
}