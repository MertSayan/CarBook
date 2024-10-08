﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Brand : Entity
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}
