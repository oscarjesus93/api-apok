using Api.Entity;

namespace Api.Service
{
    public interface IServiceBrandCar
    {
        public Task<List<BrandsCarsEntity>> GetListBransCarsAsync();
    }
}
