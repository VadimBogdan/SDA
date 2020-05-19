using DAL.Model;

namespace DAL.RepositoryInterfaces
{
    public interface ISubcategoryRepository
    {
        Subcategory GetSubcategoryById(int id);
    }
}
