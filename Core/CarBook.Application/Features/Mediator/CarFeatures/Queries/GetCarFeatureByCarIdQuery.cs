using CarBook.Application.Features.Mediator.CarFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarFeatures.Queries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFeatureByCarIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
