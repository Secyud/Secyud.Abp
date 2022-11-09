namespace Secyud.Abp;

public static class CodeDocsDbProperties
{
    public const string ConnectionStringName = "CodeDocs";
    public static string DbTablePrefix { get; set; } = "CodeDocs";

    public static string DbSchema { get; set; } = null;
}