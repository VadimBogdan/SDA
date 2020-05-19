namespace DAL.UnitOfWorkInterface
{
    public interface IUnitOfWork
    {
        void Update<TEntity>(TEntity entityToUpdate) where TEntity : class;
        int Save();
    }
}
