using CarBook.Application.Features.Mediator.Statistics.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Statistics.Queries
{
    public class GetAvgRentPriceForMonthlyQuery : IRequest<GetAvgRentPriceForMonthlyQueryResult>
    {
    }
}
