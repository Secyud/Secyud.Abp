using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BlazorComponent;
using Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Layout;

public class PageLayout : IScopedDependency, INotifyPropertyChanged
{
    private string title;

    // TODO: Consider using this property for setting Page Title too.
    public virtual string Title {
        get => title;
        set {
            title = value;
            OnPropertyChanged();
        }
    }

    private string _menuItemName;

    public string MenuItemName {
         get => _menuItemName; 
         set {
            _menuItemName = value;
            OnPropertyChanged();
         }
    }

    public virtual ObservableCollection<BreadcrumbItem> BreadcrumbItems { get; set; } = new();

    public virtual ObservableCollection<PageToolbarItem> ToolbarItems { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}