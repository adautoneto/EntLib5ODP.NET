﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntLib5Oracle
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
    }
}
