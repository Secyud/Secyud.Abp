using System;
using Microsoft.AspNetCore.Components;

namespace Secyud.Abp.Pages.CodeDocsManagement
{
    public partial class CodeClassDetailsPage
    {
        [Parameter] public Guid CodeClassId { get; set; }
        
    }
}
