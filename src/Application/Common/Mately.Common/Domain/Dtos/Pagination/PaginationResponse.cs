using Mately.Common.Domain.Dtos.Transaction;

namespace Mately.Common.Domain.Dtos.Pagination;

public class PaginationResponse<T> : ApiTransactionResult<T> where T : class
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public Uri NextPage { get; set; }
    public Uri PreviousPage { get; set; }

    public PaginationResponse(T data, int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.Data = data;
    }

    public PaginationResponse()
    {
        throw new NotImplementedException();
    }
}