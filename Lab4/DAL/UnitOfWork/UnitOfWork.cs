using DAL.Repositories;
using DAL.RepositoryInterfaces;
using DAL.UnitOfWorkInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // поля
        private readonly DbContext dataBaseContext;
        private readonly ConcurrentDictionary<Type, object> repositories;
        private readonly IDictionary<Type, Func<object>> repositoriesFactory;

        // конструктори
        public UnitOfWork(DbContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;

            this.repositoriesFactory = InitializeRepositoriesFactory();
            this.repositories = new ConcurrentDictionary<Type, object>();
        }

        private IDictionary<Type, Func<object>> InitializeRepositoriesFactory()
        {
            return new Dictionary<Type, Func<object>>()
            {
                [typeof(IUserRepository)] = () => new UserRepository(dataBaseContext),
                [typeof(IRubricRepository)] = () => new RubricRepository(dataBaseContext),
                [typeof(IAdvertisementRepository)] = () => new AdvertisementRepository(dataBaseContext),
                [typeof(ICategoryRepository)] = () => new CategoryRepository(dataBaseContext),
                [typeof(ISubcategoryRepository)] = () => new SubcategoryRepository(dataBaseContext)
            };
        }

        // методи

        public TRepositoryInterface GetRepository<TRepositoryInterface>()
        {
            Type key = typeof(TRepositoryInterface);

            return (TRepositoryInterface)repositories.GetOrAdd(key, repositoriesFactory[key].Invoke());
        }

        public int Save()
        {
            return dataBaseContext.SaveChanges();
        }

        public void Update<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            if (dataBaseContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                dataBaseContext.Set<TEntity>().Attach(entityToUpdate);
            }
            dataBaseContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
