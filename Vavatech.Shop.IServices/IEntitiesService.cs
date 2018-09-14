using System.Collections.Generic;

namespace Vavatech.Shop.IServices
{
    public interface IEntitiesService<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Edit(TEntity entity);
        TEntity Get(int Id);
        List<TEntity> Get();
    }
}
