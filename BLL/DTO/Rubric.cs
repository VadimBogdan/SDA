using System.Collections.Generic;

namespace BLL.DTO
{
    public class Rubric
    {
        public string RubricName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
