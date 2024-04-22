using Microsoft.EntityFrameworkCore;
using PRN231_Group12.Assignment2.Service.Models;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Common.Mapping;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
}