using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car : Entity
    {
        [Key]
        public int CarId { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; } 
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km {  get; set; }
        public string Transmission {  get; set; } //enum yapıya çevrilebilir (vites türü)
        public byte Seat { get; set; } // koltuk sayısı
        public sbyte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }


    }
}
