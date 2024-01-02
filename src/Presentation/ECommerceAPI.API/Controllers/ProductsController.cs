using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductsController(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
        }


        [HttpGet]
        public async Task Get()
        {
            //await _productCommandRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", CreatedDate = DateTime.UtcNow, Stock = 22, Price = 100, },
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", CreatedDate = DateTime.UtcNow, Stock = 22, Price = 100, },
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", CreatedDate = DateTime.UtcNow, Stock = 22, Price = 100, }
            //});

            Product data = await _productQueryRepository.GetBtIdAsync("22031C1E-E8FA-46E9-A511-7C5FB73DD4FB",false);
            data.Name = "Soner";
            await _productCommandRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(string id)
        {
            var entity = await _productQueryRepository.GetBtIdAsync(id);
            return Ok(entity);
        }
    }
}
