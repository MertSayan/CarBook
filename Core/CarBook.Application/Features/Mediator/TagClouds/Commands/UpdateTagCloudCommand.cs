using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.TagClouds.Commands
{
    public class UpdateTagCloudCommand:IRequest
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
    public class UpdateTagCloudCommandDTO
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
