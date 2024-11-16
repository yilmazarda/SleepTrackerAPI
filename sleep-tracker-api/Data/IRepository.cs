using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeAPI.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public  Task<IEnumerable<TEntity>> GetAllAsync();
        public  Task<TEntity> GetByIdAsync(int id);
        public Task AddAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
    }
}