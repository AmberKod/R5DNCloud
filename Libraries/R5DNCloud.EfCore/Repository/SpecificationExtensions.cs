using Ardalis.Specification;

namespace R5DNCloud.EfCore.Repository;

public static class SpecificationExtensions
{
    public static Specifications<TEntity> Create<TEntity>(this Specification<TEntity> specification)
    {
        //return new Specification<TEntity>();
        return null;
    }
}