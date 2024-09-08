using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Brands.Commands
{
    public class UpdateBrandCommand
    {
        public string Name { get; set; }
    }
}
