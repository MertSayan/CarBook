using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<string> BlogTitleByMaxBlogComment()
        {
            var value = _context.Comments.GroupBy(x => x.BlogId).
                Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName=_context.Blogs.Where(x=>x.BlogId==value.BlogId).Select(y=>y.Title).FirstOrDefault();
            return blogName;
        }

        public async Task<string> BrandNameByMaxCar()
        {
            var value = _context.Cars.GroupBy(x => x.BrandId).Select(y => new
            {
                BrandId=y.Key,
                Count=y.Count()
            }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName= _context.Brands.Where(x=>x.BrandId==value.BrandId).Select(y=>y.Name).FirstOrDefault();
            return brandName;
        }

        public async Task<int> GetAuthorCount()
        {
            var value = _context.Authors.Where(x=>x.DeletedDate==null).Count();
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForDaily()
        {
            int id= _context.Pricings.Where(x=>x.Name=="Günlük").Select(y=>y.PricingId).FirstOrDefault();
            var value=_context.CarPricings.Where(w=>w.PricingId==id).Where(x => x.DeletedDate == null).Average(t=>t.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Where(x => x.DeletedDate == null).Average(t => t.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Where(x => x.DeletedDate == null).Average(t => t.Amount);
            return value;
        }

        public async Task<int> GetBlogCount()
        {
            var value = _context.Blogs.Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetBrandCount()
        {
            var value = _context.Brands.Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingId=_context.Pricings.Where(x=>x.Name=="Günlük").Select(y => y.PricingId).FirstOrDefault();

            decimal? amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Max(x => x.Amount);

            int carId=_context.CarPricings.Where(x=>x.Amount== amount).Select(y=>y.CarId).FirstOrDefault();
            string brandModel=_context.Cars.Where(x=>x.CarId==carId).Include(y=>y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();

            decimal? amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Min(x => x.Amount);

            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public async Task<int> GetCarCount()
        {
            var value = _context.Cars.Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetCarCountBuFuelGasolineOrDiesel()
        {
            var value=_context.Cars.Where(x=>x.Fuel=="Benzin" ||  x.Fuel=="Dizel").Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetCarCountByTransmissionIsAuto()
        {
            var value=_context.Cars.Where(x=>x.Transmission=="Otomatik").Where(x => x.DeletedDate == null).Count();
            return value;
        }

        public async Task<int> GetLocationCount()
        {
            var value = _context.Locations.Where(x => x.DeletedDate == null).Count();
            return value;
        }
    }
}
