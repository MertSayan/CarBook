using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region Istatistik1
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int carCountRandom = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.CarCount;
                ViewBag.carCountRandom=carCountRandom;
            }
            #endregion

            #region Istatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7070/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)   
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion


            #region Istatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7070/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int authorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = values3.AuthorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region Istatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7070/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.BlogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            #endregion


            #region Istatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:7070/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region Istatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:7070/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int dailyPriceRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.DailyPrice = values6.DailyPrice.ToString("0.00");
                ViewBag.DailyPriceRandom = dailyPriceRandom;
            }
            #endregion


            #region Istatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:7070/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int weeklyPriceRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.WeeklyPrice = values7.WeeklyPrice.ToString("0.00");
                ViewBag.WeeklyPriceRandom = weeklyPriceRandom;
            }
            #endregion


            #region Istatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:7070/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int monthlyPrice = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.MonthlyPrice = values8.MonthlyPrice.ToString("0.00");
                ViewBag.MonthlyPriceRandom = monthlyPrice;
            }
            #endregion

            #region Istatistik9
            var responseMessage9 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int AutoTransmissionCountRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.AutoTransmissionCount = values9.AutoTransmissionCount;
                ViewBag.AutoTransmissionCountRandom = AutoTransmissionCountRandom;
            }
            #endregion

            #region Istatistik10
            var responseMessage10 = await client.GetAsync("https://localhost:7070/api/Statistics/BrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int BrandNameRandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.BrandName = values10.BrandName;
                ViewBag.BrandNameRandom = BrandNameRandom;
            }
            #endregion

            #region Istatistik11
            var responseMessage11 = await client.GetAsync("https://localhost:7070/api/Statistics/BlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int MaxBlogCommentRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.MaxBlogComment = values11.blogTitle;
                ViewBag.MaxBlogCommentRandom = MaxBlogCommentRandom;
            }
            #endregion


            #region Istatistik12
            var responseMessage12 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int KmSmaller1000Random = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.KmSmaller1000 = values12.KmSmaller1000;
                ViewBag.KmSmaller1000Random = KmSmaller1000Random;
            }
            #endregion

            #region Istatistik13
            var responseMessage13 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarCountBuFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int GasolineOrDizelCountRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.GasolineOrDizelCount = values13.GasolineOrDizelCount;
                ViewBag.GasolineOrDizelCountRandom = GasolineOrDizelCountRandom;
            }
            #endregion

            #region Istatistik14
            var responseMessage14 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int ElectricCountRandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.ElectricCount = values14.ElectricCount;
                ViewBag.ElectricCountRandom = ElectricCountRandom;
            }
            #endregion

            #region Istatistik15
            var responseMessage15 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int CarBrandAndModelDailyMaxRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.CarBrandAndModelDailyMax = values15.CarBrandAndModelDailyMax;
                ViewBag.CarBrandAndModelDailyMaxRandom = CarBrandAndModelDailyMaxRandom;
            }
            #endregion

            #region Istatistik16
            var responseMessage16 = await client.GetAsync("https://localhost:7070/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int carBrandAndModelDailyMinRandom = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.CarBrandAndModelDailyMin = values16.carBrandAndModelDailyMin;
                ViewBag.CarBrandAndModelDailyMinRandom = carBrandAndModelDailyMinRandom;
            }
            #endregion

            return View();
        }
    }
}
