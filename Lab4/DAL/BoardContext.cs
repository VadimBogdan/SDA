using DAL.Model;
using System.Data.Entity;

namespace DAL
{
    public class BoardContext : DbContext
    {
        public BoardContext() : base("BoardDb")
        {
            //Rubric rubric = new Rubric { RubricName = "Building+" };
            //Rubrics.Add(rubric);
            //Categories.Add(new Category { CategoryName = "Rooms+", Rubric = rubric });
            //SaveChanges();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BoardContext>());
        }

        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

    }
}
