using R5DNCloud.Core.Domains;
using R5DNCloud.Core.Dtos;
using R5DNCloud.EfCore.Repository;

namespace R5DNCloud.Core.Services
{
    public interface IApiResrouceCoreService : IServiceBase<ApiResource>
    {
        /// <summary>
        /// 获取接口资源定义树列表
        /// </summary>
        /// <returns></returns>
        Task<List<MenuResourceDto>> GetTreeListAsync();
    }
}
