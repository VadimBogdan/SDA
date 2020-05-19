using BLL.DTO;
using DAL;
using DAL.Repositories;
using DAL.RepositoryInterfaces;
using DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BoardAppBLL
    {
        private readonly DALMapper Mapper = DALMapper.Instance;
        private readonly UnitOfWork UnitOfWork;

        public BoardAppBLL(BoardContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public DTO.User AuthorizeUser(string login, string pass)
        {
            var userModel = UnitOfWork.GetRepository<IUserRepository>().GetByLoginAndPass(login, pass);
            return Mapper.Map<DAL.Model.User, DTO.User>(userModel);
        }

        public bool ValidateUserLoginExist(string login)
        {
            return UnitOfWork.GetRepository<IUserRepository>().IsUserExist(login);
        }

        public DTO.User RegisterNewUser(string login, string pass)
        {
            var user = new DTO.User { Login = login, Password = pass };
            var repo = UnitOfWork.GetRepository<IUserRepository>() as GenericRepository<DAL.Model.User>;
            repo.Insert(Mapper.Map<DTO.User, DAL.Model.User>(user));
            UnitOfWork.Save();
            var newUser = UnitOfWork.GetRepository<IUserRepository>().GetByLoginAndPass(login, pass);
            return Mapper.Map<DAL.Model.User, DTO.User>(newUser);
        }

        public ICollection<DTO.Rubric> GetRubrics()
        {
            var repo = UnitOfWork.GetRepository<IRubricRepository>() as GenericRepository<DAL.Model.Rubric>;
            var rubricsModel = repo.Get().ToList();
            var rubrics = Mapper.Map<ICollection<DAL.Model.Rubric>, ICollection<DTO.Rubric>>(rubricsModel);
            return rubrics;
        }

        public ICollection<DTO.Advertisement> GetAdvertisements()
        {
            var repo = UnitOfWork.GetRepository<IAdvertisementRepository>() as GenericRepository<DAL.Model.Advertisement>;
            var advertisementsModel = repo.Get().ToList();
            var advertisements = Mapper.Map<ICollection<DAL.Model.Advertisement>, ICollection<DTO.Advertisement>>(advertisementsModel);
            return advertisements;
        }

        public ICollection<DTO.Category> GetCategoriesForRubric(DTO.Rubric rubric)
        {
            var repo = UnitOfWork.GetRepository<ICategoryRepository>() as GenericRepository<DAL.Model.Category>;
            var categoriesModel = repo.Get(c => c.Rubric.RubricName.Equals(rubric.RubricName)).ToList();
            var categories = Mapper.Map<ICollection<DAL.Model.Category>, ICollection<DTO.Category>>(categoriesModel);
            return categories;
        }

        public ICollection<DTO.Subcategory> GetSubcategoriesForCategory(DTO.Category category)
        {
            var repo = UnitOfWork.GetRepository<ISubcategoryRepository>() as GenericRepository<DAL.Model.Subcategory>;
            var subcategoriesModel = repo.Get(s => s.Category.CategoryName.Equals(category.CategoryName)).ToList();
            var subcategories = Mapper.Map<ICollection<DAL.Model.Subcategory>, ICollection<DTO.Subcategory>>(subcategoriesModel);
            return subcategories;
        }

        public void AddNewAdvertisement(string description, ICollection<string> tags, Category category, Subcategory subcategory, User user)
        {
            var advRepo = UnitOfWork.GetRepository<IAdvertisementRepository>() as GenericRepository<DAL.Model.Advertisement>;
            var categoryRepo = UnitOfWork.GetRepository<ICategoryRepository>() as GenericRepository<DAL.Model.Category>;
            var subcategoryRepo = UnitOfWork.GetRepository<ISubcategoryRepository>() as GenericRepository<DAL.Model.Subcategory>;

            var categoryModel = categoryRepo.Get(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            var subcategoryModel = subcategory != null ? subcategoryRepo.Get(subcategory.SubcategoryId) : null;
            var userModel = UnitOfWork.GetRepository<IUserRepository>().GetByLoginAndPass(user.Login, user.Password);
            var tagsModel = tags;

            var advertisement = new DAL.Model.Advertisement
            { Category = categoryModel, Subcategory = subcategoryModel, User = userModel, Tags = tagsModel, Description = description };

            advRepo.Insert(advertisement);
            UnitOfWork.Save();
        }

        public void DeleteAdvertisement(DTO.Advertisement advertisement, DTO.User user)
        {
            var repo = UnitOfWork.GetRepository<IAdvertisementRepository>() as GenericRepository<DAL.Model.Advertisement>;
            repo.Get(a => authenticateUser(advertisement, user, a));
            repo.Delete(advertisement.AdvertisementId);
            UnitOfWork.Save();
        }

        private static bool authenticateUser(DTO.Advertisement advertisement, DTO.User user, DAL.Model.Advertisement a)
        {
            return a.User.Login == user.Login && a.User.Password == user.Password && a.AdvertisementId == advertisement.AdvertisementId;
        }
    }
}
