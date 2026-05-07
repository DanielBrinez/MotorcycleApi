using System;
using System.Collections.Generic;

namespace MotorcycleApi.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Email {get; set;} ="";
        public string Password {get; set;} ="";
    }
}