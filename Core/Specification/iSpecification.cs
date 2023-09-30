using System.Linq.Expressions;

namespace Core.Specification;

public interface iSpecification<T> 
{
    Expression<Func<T,bool>> Criteria {get; }
    List<Expression<Func<T,object>>> Includes {get; }
    
}
