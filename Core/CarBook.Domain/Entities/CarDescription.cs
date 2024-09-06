using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarDescription : Entity
    {
        [Key]
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Details { get; set; }
    }
}
