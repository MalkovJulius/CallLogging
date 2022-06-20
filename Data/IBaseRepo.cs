namespace CallLogging.Data
{
    public interface IBaseRepo<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T instance);
        Task UpdateAsync(T instance);
        Task DeleteAsync(T instance);
    }
}
