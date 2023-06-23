using System.ComponentModel.DataAnnotations;

namespace AlmuzainiCMS.Models.LoginVM
{
    public class UsersInfoVM
    {
        [Key]
        public int Id { get; set; }


        public string? userCode { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string? userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? userPass { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("userPass")]
        public string? confirmUserPass { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? userEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? userPhone { get; set; }
        public string? userType { get; set; }
        public string? userRole { get; set; }
        [DataType(DataType.DateTime)]
        public string? userCreateDate { get; set; }
    }
}
