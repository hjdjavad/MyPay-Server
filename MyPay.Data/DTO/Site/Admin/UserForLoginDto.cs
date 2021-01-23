using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace MyPay.Data.DTO.Site.Admin
{
    public class UserForLoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsMember { get; set; }
    }
}
