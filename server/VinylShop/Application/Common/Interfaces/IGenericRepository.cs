namespace Application.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetList();

        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Update(TEntity entityToUpdate);
    }
}
