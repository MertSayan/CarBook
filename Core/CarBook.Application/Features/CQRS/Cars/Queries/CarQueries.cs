using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Cars.Queries
{
    public class CarQueries
    {
        public int Id { get; set; }

        public CarQueries(int id)
        {
            Id = id;
        }
    }
}
