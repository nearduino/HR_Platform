namespace HR_Platform.Repository.Abstractions
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> Get(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task Delete(TKey id);
        Task Complete();
    }
}
