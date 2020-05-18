using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string Login { get; set; }
        [MinLength(3)]
        public string Password { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
