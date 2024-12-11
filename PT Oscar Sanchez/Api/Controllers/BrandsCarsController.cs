using Api.DTO;
using Api.Entity;
using Api.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsCarsController : ControllerBase
    {
        private readonly IServiceBrandCar _service;
        private readonly IMapper _mapper;

        public BrandsCarsController(IServiceBrandCar service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandsCarsDTO>>> GetListAsync()
        {
            try
            {
                List<BrandsCarsEntity> brandsCarsEntities = await this._service.GetListBransCarsAsync();
                List<BrandsCarsDTO> brandsCars = this._mapper.Map<List<BrandsCarsDTO>>(brandsCarsEntities);

                return Ok(brandsCars);
            }
            catch (ExceptionCustom ex)
            {
                if (ex.code == HttpStatusCode.NotFound)
                    return NotFound(new MessageResponseException(ex.Message));

                return BadRequest(new MessageResponseException(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new MessageResponseException(ex.Message));
            }
        }
    }
}
