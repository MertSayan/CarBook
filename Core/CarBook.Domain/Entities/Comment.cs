﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Comment:Entity
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public string Email {  get; set; }
    }
}
