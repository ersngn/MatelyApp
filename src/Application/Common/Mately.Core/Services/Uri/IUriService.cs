using Mately.Common.Domain.Dtos.Pagination;

namespace Mately.Core.Services.Uri;

public interface IUriService
{
    System.Uri GetPageUri(PaginationFilter filter, string route);
}