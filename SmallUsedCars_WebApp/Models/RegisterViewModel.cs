﻿using System.ComponentModel.DataAnnotations;

namespace SmallUsedCars_WebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName {  get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
