using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Banner : Entity
    {
        [Key]
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription  { get; set; }
        public string VideoUrl { get; set; }
    }
}
