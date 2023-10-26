using Microsoft.EntityFrameworkCore;

namespace TnActivationCore.Repository.Mssql
{
    public class PaginationSpecification<T> : SpecificationBase<T>
        where T : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}