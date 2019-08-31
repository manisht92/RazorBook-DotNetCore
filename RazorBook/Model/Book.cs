﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RazorBook.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
    }
}
