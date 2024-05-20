namespace R5DNCloud.Infrastructure.Dtos
{
    /// <summary>
    /// DTO 基础类
    /// </summary>
    public class Dto
    {
    }

    public abstract class Dto<TKey>: Dto
    {
        public virtual TKey Id { get; set; }
    }
}
