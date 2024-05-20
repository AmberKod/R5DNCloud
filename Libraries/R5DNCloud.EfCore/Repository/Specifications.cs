using Ardalis.Specification;

namespace R5DNCloud.EfCore.Repository;

public class Specifications<TEntity> : Specification<TEntity>
{
    public static Specifications<TEntity> Create()
    {
        return new Specifications<TEntity>();
    }

    public new ISpecificationBuilder<TEntity> Query => base.Query;
}

public class Specifications<TEntity, TResult> : Specification<TEntity, TResult>
{
    public static Specifications<TEntity, TResult> Create()
    {
        return new Specifications<TEntity, TResult>();
    }

    public new ISpecificationBuilder<TEntity, TResult> Query => base.Query;
}