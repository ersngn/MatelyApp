using Mately.Common.Domain.Dtos.Pagination;
using Mately.Core.Services.Uri;

namespace Mately.Core.Extentions;

public static class PaginationExtention
{
    public static PaginationResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
    {
        var respose = new PaginationResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        respose.NextPage =
            validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
        respose.PreviousPage =
            validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
        respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
        respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
        respose.TotalPages = roundedTotalPages;
        respose.TotalRecords = totalRecords;
        return respose;
    }
}