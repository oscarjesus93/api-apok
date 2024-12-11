using Api;
using Api.Controllers;
using Api.DTO;
using Api.Entity;
using Api.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Test
{

    public class TestService
    {
        private readonly Mock<IServiceBrandCar> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly BrandsCarsController _brandsControllers;

        public TestService()
        {
            this._mockService = new Mock<IServiceBrandCar>();
            this._mockMapper = new Mock<IMapper>();
            this._brandsControllers = new BrandsCarsController(this._mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestListBrandCar()
        {
            this._mockService.Setup(f => f.GetListBransCarsAsync()).ReturnsAsync(new List<BrandsCarsEntity>());
            this._mockMapper.Setup(m => m.Map<List<BrandsCarsDTO>>(It.IsAny<List<BrandsCarsEntity>>())).Returns(new List<BrandsCarsDTO>());

            ActionResult<List<BrandsCarsDTO>> result = await this._brandsControllers.GetListAsync();

            OkObjectResult okResult = (OkObjectResult)(result.Result);
            Assert.Equal(200, okResult.StatusCode);

            var responseData = Assert.IsType<List<BrandsCarsDTO>>(okResult.Value);
            Assert.NotNull(responseData); 
        }

        [Fact]
        public async Task TestListBrandCarNotFound()
        {
            this._mockService.Setup(f => f.GetListBransCarsAsync()).ThrowsAsync(new ExceptionCustom("No se encontraron resultados", System.Net.HttpStatusCode.NotFound));
            this._mockMapper.Setup(m => m.Map<List<BrandsCarsDTO>>(It.IsAny<List<BrandsCarsEntity>>())).Returns(new List<BrandsCarsDTO>());

            ActionResult<List<BrandsCarsDTO>> result = await this._brandsControllers.GetListAsync();

            NotFoundObjectResult notFoundResult = (NotFoundObjectResult)(result.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);

            MessageResponseException exception = (MessageResponseException)notFoundResult.Value;
            Assert.Equal("No se encontraron resultados", exception.Message);
        }

        [Fact]
        public async Task TestListBrandCarInternalError()
        {
            this._mockService.Setup(f => f.GetListBransCarsAsync()).ThrowsAsync(new Exception());
            this._mockMapper.Setup(m => m.Map<List<BrandsCarsDTO>>(It.IsAny<List<BrandsCarsEntity>>())).Returns(new List<BrandsCarsDTO>());

            ActionResult<List<BrandsCarsDTO>> result = await _brandsControllers.GetListAsync();

            ObjectResult errorResult = (ObjectResult)(result.Result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, errorResult.StatusCode);
        }
    }
}
