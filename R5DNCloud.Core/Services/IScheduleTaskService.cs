using R5DNCloud.Core.Domains;
using R5DNCloud.EfCore.Repository;

namespace R5DNCloud.Core.Services
{
    public interface IScheduleTaskService: IServiceBase<ScheduleTask>
    {
        /// <summary>
        /// 初始化定时任务
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}
