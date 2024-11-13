﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample.Core.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Customer()
        {

        }

    }
}
