﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
