using PlatformShop.Domain.Base;


namespace PlatformShop.Domain.Repositories
{
    interface IBaseRepository<TEintity, TModel> where TEintity : class
    {
        Task<OperationResult<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task AddAsync(TEintity entity);
        Task UpdateAsync(TEintity entity);
        Task DeleteAsync(int id);
    }
}
