using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Account;

namespace WebApi.ModelsAndDtoes.Profile
{
    public class EditProfileApiDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(1, 2)]
        public UserType UserType { get; set; }
    }
}
