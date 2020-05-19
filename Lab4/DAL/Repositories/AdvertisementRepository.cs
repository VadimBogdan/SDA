using DAL.Model;
using DAL.RepositoryInterfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(DbContext dbContext)
            : base(dbContext) { }
    }
}
