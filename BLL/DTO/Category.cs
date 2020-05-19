using System.Collections.Generic;

namespace BLL.DTO
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Rubric Rubric { get; set; }
        public List<Advertisement> Advertisements { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }
}
