using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBoardService
    {
        DTO.User AuthorizeUser(string login, string pass);

        bool VerifyUserLoginExist(string login);

        DTO.User RegisterNewUser(string login, string pass);

        ICollection<DTO.Rubric> GetRubrics();

        ICollection<DTO.Advertisement> GetAdvertisements();

        ICollection<DTO.Category> GetCategoriesForRubric(DTO.Rubric rubric);

        ICollection<DTO.Subcategory> GetSubcategoriesForCategory(DTO.Category category);

        void AddNewAdvertisement(string description, ICollection<string> tags, Category category, Subcategory subcategory, User user);

        void DeleteAdvertisement(DTO.Advertisement advertisement, DTO.User user);
    }
}
