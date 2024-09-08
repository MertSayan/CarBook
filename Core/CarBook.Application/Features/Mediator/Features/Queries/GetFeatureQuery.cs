using CarBook.Application.Features.Mediator.Features.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Features.Queries
{
    public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
    {
    }
}
