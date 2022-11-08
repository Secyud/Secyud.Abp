using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class AbpExtensibleDataGrid<TItem> : ComponentBase
{
    [Inject] public IStringLocalizerFactory StringLocalizerFactory { get; set; }
    
    [Parameter] public IEnumerable<TItem> Items { get; set; }

    [Parameter] public EventCallback<DataOptions> OnOptionsUpdate { get; set; }

    [Parameter] public IEnumerable<DataTableHeader<TItem>> Headers { get; set; }
    
    [Parameter] public int TotalItems { get; set; }

    [Parameter] public bool DisablePagination { get; set; }

    [Parameter] public string Class { get; set; }
    
    [Parameter] public List<EntityAction> EntityActions { get; set; }
    
    [Parameter] public RenderFragment<ItemColProps<TItem>> ColTemplate { get; set; }

    [Parameter] public ActionType ActionType { get; set; } = ActionType.Dropdown;

    protected const string DataFieldAttributeName = "Data";

    protected Regex ExtensionPropertiesRegex = new Regex(@"ExtraProperties\[(.*?)\]");
    
    protected virtual RenderFragment RenderCustomTableColumnComponent(Type type, object data)
    {
        return (builder) =>
        {
            builder.OpenComponent(0, type);
            builder.AddAttribute(0, DataFieldAttributeName, data);
            builder.CloseComponent();
        };
    }
    
    protected virtual string GetConvertedFieldValue(TItem item, TableColumn columnDefinition)
    {
        var convertedValue = columnDefinition.ValueConverter.Invoke(item);
        if (!columnDefinition.DisplayFormat.IsNullOrEmpty())
        {
            return string.Format(columnDefinition.DisplayFormatProvider, columnDefinition.DisplayFormat,
                convertedValue);
        }
        return convertedValue;
    }
}
