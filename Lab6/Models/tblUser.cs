using System.ComponentModel.DataAnnotations;

namespace Lab06_ASPNET_MVC.Models
{
    public class tblUser
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
