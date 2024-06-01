namespace Fina.Core.Request
{
    public abstract class PagedRequest
    {
        public long PageSize { get; set; } = Configuration.DefaultPageSize;
        public long PageNumber { get; set; } = Configuration.DefaultPageNumber;

    }
}
