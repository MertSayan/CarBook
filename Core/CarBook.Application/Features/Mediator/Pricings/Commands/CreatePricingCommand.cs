﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Pricings.Commands
{
    public class CreatePricingCommand:IRequest
    {
        public string Name { get; set; }
    }
}