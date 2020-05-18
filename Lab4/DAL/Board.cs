using DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Board
    {
        public readonly static Board Instance = new Board(BoardContext.Instance);
        private readonly BoardContext ctx;

        public ICollection<Rubric> Rubrics
        {
            get { return ctx.Rubrics.Select(r => r).ToList(); }
        }

        public ICollection<Advertisement> Advertisements
        {
            get { return ctx.Advertisements.Select(r => r).ToList(); }
        }

        public ICollection<Category> Categories(Rubric rubric)
        {
            return ctx.Categories.Where(c => c.Rubric.RubricName.Equals(rubric.RubricName)).ToList();
        }

        public ICollection<Subcategory> Subcategories(Category category)
        {
            return ctx.Subcategories.Where(s => s.Category.CategoryName.Equals(category.CategoryName)).ToList();
        }

        private Board(BoardContext ctx)
        {
            this.ctx = ctx;
        }

        public bool VerifyUserLogin(string login)
        {
            return ctx.Users.Where(u => u.Login == login).FirstOrDefault() != null;
        }

        public bool VerifyUserPassword(string password)
        {
            return ctx.Users.Where(u => u.Password == password).FirstOrDefault() != null;
        }

        public User User(string login, string password)
        {
            if (!VerifyUserLogin(login))
            {
                ctx.Users.Add(new User { Login = login, Password = password });
                ctx.SaveChanges();
            }
            return ctx.Users.First(u => u.Login == login && u.Password == password);
        }

        public void NewAdvert(Advertisement advertisement)
        {
            ctx.Advertisements.Add(advertisement);
            ctx.SaveChanges();
        }

        public void RemoveAdvert(User user, Advertisement advertisement)
        {
            Advertisement adv = ctx.Users.First(u => u.Login == user.Login && u.Password == user.Password)
                .Advertisements.First(a => a.AdvertisementId == advertisement.AdvertisementId);
            if (adv != null)
            {
                ctx.Advertisements.Remove(adv);
                ctx.SaveChanges();
            }
        }
    }
}
