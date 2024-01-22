﻿using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;


        public virtual ICollection<User> Users { get; set; }
    }
}
