using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Rubric
    {
        [Key]
        public string RubricName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
