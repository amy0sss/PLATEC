using System.ComponentModel.DataAnnotations;

namespace PLACTECUGHH.Models
{
    public class User
    {
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string passWord { get; set; }
    }
}
