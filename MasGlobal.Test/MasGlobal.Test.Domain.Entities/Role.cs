﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Role()
        {

        }

        public Role(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
