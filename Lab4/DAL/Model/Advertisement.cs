using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Advertisement
    {
        [Key]
        public int AdvertisementId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
