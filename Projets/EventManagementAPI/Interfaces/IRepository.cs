using System.Linq.Expressions;

namespace EventManagementAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        // Update is often handled by getting the entity, modifying it, and calling SaveChangesAsync in the service/unit of work
        // Task UpdateAsync(T entity); // Optional: Add if you prefer explicit update method
        Task<int> SaveChangesAsync(); // Add SaveChangesAsync here or use a Unit of Work pattern
    }
}