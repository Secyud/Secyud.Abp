namespace SuperCreation.Abp.CodeDocs;

public static class CodeDocsDbProperties
{
    public static string DbTablePrefix { get; set; } = "CodeDocs";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CodeDocs";
}
