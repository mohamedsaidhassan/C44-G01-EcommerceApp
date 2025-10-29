using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shared.DataTransferObjects
{
    public record PaginatedResult<TResult>(int pageindex,int pagecount,int totalcount, IEnumerable<TResult>Data);

}
