using System.Linq;
using System.Threading.Tasks;
using GenericLibsBase;
using GenericServices;
using GenericServices.Core;
using GenericServices.Services;
using GenericServices.ServicesAsync;

namespace Spa.Infrastructure
{
    public class SpaRepository<TEntity, TDto, TDtoAsync> : ISpaRepository<TEntity, TDto, TDtoAsync>
        where TEntity : class, new()
        where TDto : EfGenericDto<TEntity, TDto>, new()
        where TDtoAsync : EfGenericDtoAsync<TEntity, TDtoAsync>, new()
    {

        #region Service fields for property injections with <TEntity> generic
        public IListService<TEntity> ListService { get; set; }
        public IDetailServiceAsync<TEntity> DetailServiceAsync { get; set; }
        public IDetailService<TEntity> DetailService { get; set; }
        public ICreateServiceAsync<TEntity> CreateServiceAsync { get; set; }
        public IUpdateServiceAsync<TEntity> UpdateServiceAsync { get; set; }
        #endregion

        public IDeleteServiceAsync DeleteServiceAsync { get; set; }

        #region Service fields for property injections with <TEntity, TDto> generics
        public IListService<TEntity, TDto> ListServiceDto { get; set; }
        public IDetailServiceAsync<TEntity, TDtoAsync> DetailServiceDtoAsync { get; set; }
        public IDetailService<TEntity, TDto> DetailServiceDto { get; set; }
        public ICreateServiceAsync<TEntity, TDtoAsync> CreateServiceDtoAsync { get; set; }
        public IUpdateServiceAsync<TEntity, TDtoAsync> UpdateServiceDtosync { get; set; }
        #endregion

        #region CRUD methods with <TEntity> generic
        public IQueryable<TEntity> GetAll()
        {
            return ListService.GetAll();
        }
        public async Task<ISuccessOrErrors<TEntity>> GetAsync(int key)
        {
            return await DetailServiceAsync.GetDetailAsync(key);
        }
        public ISuccessOrErrors<TEntity> Get(int key)
        {
            return DetailService.GetDetail(key);
        }

        public async Task<ISuccessOrErrors> PostAsync(TEntity entity)
        {
            return await CreateServiceAsync.CreateAsync(entity);
        }

        public async Task<ISuccessOrErrors> PatchAsync(TEntity entity)
        {
            return await UpdateServiceAsync.UpdateAsync(entity);
        }
        #endregion

        public async Task<ISuccessOrErrors> DeleteAsync(int key)
        {
            return await DeleteServiceAsync.DeleteAsync<TEntity>(key);
        }

        #region CRUD methods with <TDto, TDtoAsync> generic
        public IQueryable<TDto> GetAllDto()
        {
            return ListServiceDto.GetAll();
        }
        public async Task<ISuccessOrErrors<TDtoAsync>> GetDtoAsync(int key)
        {
            return await DetailServiceDtoAsync.GetDetailAsync();
        }
        public ISuccessOrErrors<TDto> GetDto(int key)
        {
            return DetailServiceDto.GetDetail(key);
        }

        public async Task<ISuccessOrErrors> PostDtoAsync(TDtoAsync dto)
        {
            return await CreateServiceDtoAsync.CreateAsync(dto);
        }

        public async Task<ISuccessOrErrors> PatchDtoAsync(TDtoAsync dto)
        {
            return await UpdateServiceDtosync.UpdateAsync(dto);
        }
        #endregion
    }
}