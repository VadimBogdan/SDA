using DAL.Model;
using System.Data.Entity;

namespace DAL
{
    public class BoardContext : DbContext
    {
        public readonly static BoardContext Instance = new BoardContext();
        private BoardContext() : base("BoardDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BoardContext>());
        }

        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

    }
}
