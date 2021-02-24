using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vocabulary.Services
{
    public interface ICrudService<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> FindAll();
        Task<IEnumerable<Entity>> FindAll(BaseFilter<Entity> filter);
        Task<Entity> Find(int id);
        Task<Entity> Add(Entity entity);
        Task<Entity> Update(Entity entity);
        Task<(bool, string)> UpdateRange(IEnumerable<Entity> entities);
        Task Remove(int id);
    }
}
