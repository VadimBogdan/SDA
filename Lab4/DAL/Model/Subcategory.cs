using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        [Required]
        public string SubcategoryName { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
