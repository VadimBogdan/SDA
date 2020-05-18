using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Tag
    {
        [Key]
        public string TagName { get; set; }
    }
}
