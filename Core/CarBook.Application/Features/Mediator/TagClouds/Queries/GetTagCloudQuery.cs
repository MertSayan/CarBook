using CarBook.Application.Features.Mediator.TagClouds.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.TagClouds.Queries
{
    public class GetTagCloudQuery:IRequest<List<GetTagCloudQueryResult>>
    {
    }
}
