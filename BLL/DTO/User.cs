using System.Collections.Generic;

namespace BLL.DTO
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
