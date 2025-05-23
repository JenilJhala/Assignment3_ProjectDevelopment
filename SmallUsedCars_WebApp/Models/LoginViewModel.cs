﻿using System.ComponentModel.DataAnnotations;

namespace SmallUsedCars_WebApp.Models
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.EmailAddress)] 
        public string Email { get; set; }

        [Required, DataType(DataType.Password)] 
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
