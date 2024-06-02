using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Fina.Core.Response
{
    public class PagedResponse<TData> : Response<TData>
    {
        public long CurrentPage { get; set; }
        public long PageSize { get; set; } = Configuration.DefaultPageSize;
        public long TotalPages => (long)Math.Ceiling(TotalCount / (double)PageSize);
        public long TotalCount { get; set; }
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            long totalCount,
            long currentPage = 1,
            long pageSize = Configuration.DefaultPageSize)
            : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;

        }
        public PagedResponse(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {
        }
    }
}
