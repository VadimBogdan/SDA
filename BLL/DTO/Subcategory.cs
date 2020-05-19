using System.Collections.Generic;

namespace BLL.DTO
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public Category Category { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
