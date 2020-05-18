using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public virtual Rubric Rubric { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
