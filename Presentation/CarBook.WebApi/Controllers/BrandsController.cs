using CarBook.Application.Features.CQRS.Brands.Commands;
using CarBook.Application.Features.CQRS.Brands.Handlers.Read;
using CarBook.Application.Features.CQRS.Brands.Handlers.Write;
using CarBook.Application.Features.CQRS.Brands.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandCommendHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommendHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommendHandler _removeBrandCommandHandler;

        public BrandsController(GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            GetBrandQueryHandler getBrandQueryHandler,
            CreateBrandCommendHandler createBrandCommandHandler,
            UpdateBrandCommendHandler updateBrandCommandHandler,
            RemoveBrandCommendHandler removeBrandCommandHandler)
        {
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand basariyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand basariyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand basariyla güncellendi");
        }
    }
}
