﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Commands
{
    public class RemoveBlogCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int id)
        {
            Id = id;
        }
    }
}
