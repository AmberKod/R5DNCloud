using R5DNCloud.Core.Domains;
using R5DNCloud.RabbitMQ.EventBus;

namespace R5DNCloud.Core.EventData
{
    /// <summary>
    /// 异步任务传输数据
    /// </summary>
    public class AsyncTaskEventData: EventBase
    {
        public AsyncTaskEventData()
        { }

        public AsyncTaskEventData(long id, string code)
        {
            this.TaskId = id;
            this.TaskCode = code;
        }
        public AsyncTaskEventData(AsyncTask asyncTask)
            : this(asyncTask.Id, asyncTask.Code)
        {

        }


        
        /// <summary>
        /// 异步任务编码
        /// </summary>
        public string TaskCode { get; set; }

        /// <summary>
        /// 异步任务Id
        /// </summary>
        public long TaskId { get; set; }
    }
}
