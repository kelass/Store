﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DbModels
{
    public class Characteristic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        
    }
}
