using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.Shop.IServices
{
    public interface IEntityServiceAsync<TEntity>
    {
        //void Add(TEntity entity);
        //void Remove(TEntity entity);
        //void Edit(TEntity entity);
        Task<TEntity> GetAsync(int Id);
        Task<List<TEntity>> GetAsync();
    }
}
