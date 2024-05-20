﻿using R5DNCloud.EfCore.Entities;

namespace R5DNCloud.Core.Domains
{
    /// <summary>
    /// 定时任务
    /// </summary>
    public class ScheduleTask: EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 代码，默认为 Schedule 的类名
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 是否启用的状态
        /// </summary>   
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// Cron 表达式
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public DateTime NextExecuteTime { get; set; }

        /// <summary>
        /// 最后一次执行时间
        /// </summary>
        public DateTime LastExecuteTime { get; set; }
    }
}
