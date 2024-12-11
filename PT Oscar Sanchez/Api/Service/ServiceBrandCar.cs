using Api.Config;
using Api.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api.Service
{
    public class ServiceBrandCar : IServiceBrandCar
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceBrandCar( ApplicationDbContext applicationDb )
        {            
            this._dbContext = applicationDb;
        }

        public async Task<List<BrandsCarsEntity>> GetListBransCarsAsync()
        {
            try
            {
                List<BrandsCarsEntity> brandsCarsEntities = new List<BrandsCarsEntity>();

                brandsCarsEntities = await this._dbContext.BrandsCars.ToListAsync();

                if (brandsCarsEntities.Count == 0)
                    throw new ExceptionCustom("No se encontraron resultados", HttpStatusCode.NotFound);

                return brandsCarsEntities;
            }
            catch (ExceptionCustom ex)
            {               
                throw new ExceptionCustom(ex.Message, ex.code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
