using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelsAndDtoes.Account
{
    
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(1, 2)]
        public UserType UserType { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
