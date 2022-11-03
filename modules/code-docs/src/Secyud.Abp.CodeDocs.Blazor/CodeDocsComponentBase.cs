using BlazorComponent;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using OneOf;
using SuperCreation.Abp.CodeDocs.Localization;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Components;

namespace SuperCreation.Abp.CodeDocs.Blazor;

public abstract class CodeDocsComponentBase : AbpComponentBase
{
    [Inject] public IPopupService PopupService { get; set; }
    protected CodeDocsComponentBase()
    {
        LocalizationResource = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsBlazorModule);
    }


    protected void FooterProps(IDataFooterParameters dataFooterParameters)
    {
        dataFooterParameters.ItemsPerPageOptions = new List<OneOf<int, DataItemsPerPageOption>>() { 5, 10, 15 };
    }
}
