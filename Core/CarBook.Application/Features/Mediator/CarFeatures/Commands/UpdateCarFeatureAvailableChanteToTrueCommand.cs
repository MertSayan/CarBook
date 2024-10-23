using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarFeatures.Commands
{
    public class UpdateCarFeatureAvailableChanteToTrueCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChanteToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
