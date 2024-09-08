using CarBook.Application.Features.Mediator.Locations.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Locations.Queries
{
    public class GetLocationQuery:IRequest<List<GetLocationQueryResult>>
    {
    }
}
