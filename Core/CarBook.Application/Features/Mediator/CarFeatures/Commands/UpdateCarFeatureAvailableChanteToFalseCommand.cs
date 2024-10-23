using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarFeatures.Commands
{
    public class UpdateCarFeatureAvailableChanteToFalseCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChanteToFalseCommand(int id)
        {
            Id = id;
        }
    }
}
