﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Customer (int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
