﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string? Password { get; set; }
    }
}
