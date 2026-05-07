using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleApi.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [MaxLength(50)]
        public string Email {get; set;} ="";
        
        [Required]
        [MaxLength(100)]
        public string Password {get; set;}="";
    }
}