using System.Collections.Generic;

namespace Vavatech.Shop.IServices
{
    public interface IIsSearchable<TEntity>
    {
        List<TEntity> Search(string query);
    }
}
