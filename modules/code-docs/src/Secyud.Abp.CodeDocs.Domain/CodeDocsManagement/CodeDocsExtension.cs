using System;
using System.Linq;

namespace Secyud.Abp.CodeDocsManagement;

public static class CodeDocsExtension
{
    public static IQueryable<CodeClass> ApplyFilter(
        this IQueryable<CodeClass> query,
        string name = null,
        bool? isVisible = null)
    {
        return query
            .WhereIf(!name.IsNullOrEmpty(), u => u.Name.Contains(name))
            .WhereIf(isVisible is not null, u => u.IsVisible == isVisible);
    }

    public static IQueryable<CodeFunction> ApplyFilter(
        this IQueryable<CodeFunction> query,
        Guid classId = default,
        string name = null)
    {
        return query
            .WhereIf(!name.IsNullOrEmpty(), u => u.Name.Contains(name))
            .WhereIf(classId != default, u => u.ClassId == classId);
    }
}