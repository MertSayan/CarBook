using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public int AutoTransmissionCount { get; set; }
        public int KmSmaller1000 { get; set; }

        public int GasolineOrDizelCount { get; set; }

        public int ElectricCount { get; set; }

        public string CarBrandAndModelDailyMax { get; set; }
        public string carBrandAndModelDailyMin { get; set; }
        public string BrandName { get; set; }
        public string blogTitle { get; set; }


    }
}
