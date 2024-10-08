using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.TagClouds.Commands
{
    public class RemoveTagCloudCommend:IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudCommend(int id)
        {
            Id = id;
        }
    }
}
