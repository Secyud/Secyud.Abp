using Microsoft.EntityFrameworkCore;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Secyud.Abp.EntityFrameworkCore;

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
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeDocsConsts.MaxNameLength);
            b.Property(q => q.Description).HasMaxLength(CodeDocsConsts.MaxDescriptionLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeDocsConsts.MaxDescriptionLength);

            b.HasMany(x => x.Parameters)
                .WithOne()
                .HasForeignKey(x => x.ClassId);
            
            b.HasIndex(u => u.Name);
        });
        
        builder.Entity<ClassParameter>(b =>
        {
            b.ToTable(nameof(ClassParameter));
            b.ConfigureByConvention();
            
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeDocsConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeDocsConsts.MaxAnnotationLength);

            b.HasKey(u => new {u.ClassId, u.Name,  });
        });
        
        builder.Entity<CodeFunction>(b =>
        {
            b.ToTable(nameof(CodeFunction));
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeDocsConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeDocsConsts.MaxAnnotationLength);

            b.HasMany(x => x.Parameters)
                .WithOne()
                .HasForeignKey(x => x.FunctionId);

            b.HasIndex(u => u.ClassId);
        });
        
        builder.Entity<FunctionParameter>(b =>
        {
            b.ToTable(nameof(FunctionParameter));
            b.ConfigureByConvention();
            
            b.Property(q => q.Name).IsRequired().HasMaxLength(CodeDocsConsts.MaxNameLength);
            b.Property(q => q.Annotation).HasMaxLength(CodeDocsConsts.MaxAnnotationLength); 
            
            b.HasKey(u => new { u.FunctionId, u.Name });
        });
    }
}
