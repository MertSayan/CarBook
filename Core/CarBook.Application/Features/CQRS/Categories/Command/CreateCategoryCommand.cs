﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Categories.Command
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
    }
}