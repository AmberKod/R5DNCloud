namespace R5DNCloud.EfCore.Entities;

public class AuditedEntity
{
    
}

public abstract class AuditedEntity<TKey> : EntityBase<TKey>, IAuditedEntity