using Microsoft.EntityFrameworkCore;
using SuperCreation.Abp.CodeDocs.Code;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SuperCreation.Abp.CodeDocs.EntityFrameworkCore;

public static class CodeDocsDbContextModelCreatingExtensions
{
    public static void ConfigureCodeDocs(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<CodeClass>(b =>
        {
            b.ToTable(nameof(CodeClass));
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeConsts.MaxNameLength);
            b.Property(q => q.Description).HasMaxLength(CodeConsts.MaxDescriptionLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeConsts.MaxDescriptionLength);

            b.HasMany(x => x.Parameters).WithOne().HasForeignKey(x => x.ClassId).IsRequired();
            b.HasMany(x => x.Functions).WithOne().HasForeignKey(x => x.ClassId).IsRequired();
            b.HasMany<CodeClass>().WithOne(x => x.Parent).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
            b.HasMany<CodeFunction>().WithOne(x => x.Return).HasForeignKey(x => x.ReturnId).OnDelete(DeleteBehavior.NoAction);
            b.HasMany<ClassParameter>().WithOne(x => x.Type).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
            b.HasMany<FunctionParameter>().WithOne(x => x.Type).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<ClassParameter>(b =>
        {
            b.ToTable(nameof(ClassParameter));
            b.ConfigureByConvention();
            b.HasKey(q=> new { q.Name, q.ClassId });
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeConsts.MaxAnnotationLength);
        });
        builder.Entity<CodeFunction>(b =>
        {
            b.ToTable(nameof(CodeFunction));
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeConsts.MaxAnnotationLength);

            b.HasMany(x => x.Parameters).WithOne().HasForeignKey(x => x.FunctionId).IsRequired();
        });
        builder.Entity<FunctionParameter>(b =>
        {
            b.ToTable(nameof(FunctionParameter));
            b.ConfigureByConvention();
            b.HasKey(q => new {q.Name,q.FunctionId });
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeConsts.MaxAnnotationLength);
        });
    }
}
