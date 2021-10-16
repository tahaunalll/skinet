using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifitions
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        //specified number of contiguous elements from the start of a sequence
        int Take { get; }
        //Bypasses a specified number of elements in a sequence
        int Skip { get; }
        bool IsPagingEnabled { get; }

    }
}