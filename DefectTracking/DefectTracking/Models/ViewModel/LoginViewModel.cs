﻿using System.ComponentModel.DataAnnotations;

namespace DefectTracking.Models
{
    public class LoginViewModel //Account Controller
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
