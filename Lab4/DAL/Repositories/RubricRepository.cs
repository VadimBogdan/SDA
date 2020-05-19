using DAL.Model;
using DAL.RepositoryInterfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class RubricRepository : GenericRepository<Rubric>, IRubricRepository
    {
        public RubricRepository(DbContext dbContext)
            : base(dbContext) { }
    }
}
