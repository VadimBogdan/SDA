using System.Collections.Generic;

namespace BLL.DTO
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public List<string> Tags { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
