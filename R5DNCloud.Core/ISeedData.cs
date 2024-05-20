﻿using R5DNCloud.Core.Domains;

namespace R5DNCloud.Core
{
    /// <summary>
    /// 数据初始化接口
    /// </summary>
    public interface ISeedData
    {
        /// <summary>
        /// 数据初始化顺序
        /// </summary>
        int Order { get; }

        /// <summary>
        /// 如果初始化数据是一个文件，则要进行设置,如果不需要文件，则设置为null
        /// </summary>
        string ConfigPath { get; set; }

        /// <summary>
        /// 执行初始化数据的逻辑
        /// </summary>
        /// <returns></returns>
        Task ApplyAsync(SeedDataTask model);
    }
}
