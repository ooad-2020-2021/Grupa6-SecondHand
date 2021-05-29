﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Administrator
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Passwrod { get; set; }

        public Administrator()
        {
        }
    }
}
