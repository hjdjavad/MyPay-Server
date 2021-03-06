﻿using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace MyPay.Data.DTO.Site.Admin
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength:10,MinimumLength = 4,ErrorMessage = "پسورد وارد شده باید بین 4 تا 10 رقم باشد")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
