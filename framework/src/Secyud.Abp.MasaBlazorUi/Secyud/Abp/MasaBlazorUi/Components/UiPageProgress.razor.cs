using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Progression;

namespace Secyud.Abp.MasaBlazorUi.Components;

public partial class UiPageProgress
{
    [Inject] protected IUiPageProgressService UiPageProgressService { get; set; }

    protected int Percentage { get; set; }

    protected bool Visible { get; set; }

    protected bool Indeterminate { get; set; }

    protected string Color { get; set; }

    public virtual void Dispose()
    {
        if (UiPageProgressService != null)
            UiPageProgressService.ProgressChanged -= OnProgressChanged;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UiPageProgressService.ProgressChanged += OnProgressChanged;
    }

    protected virtual string GetColor(UiPageProgressType pageProgressType)
    {
        return pageProgressType switch
        {
            UiPageProgressType.Info => StyleColor.Info,
            UiPageProgressType.Success => StyleColor.Success,
            UiPageProgressType.Warning => StyleColor.Warning,
            UiPageProgressType.Error => StyleColor.Error,
            _ => null
        };
    }

    private async void OnProgressChanged(object sender, UiPageProgressEventArgs e)
    {
        Percentage = e.Percentage ?? 100;
        Visible = Percentage is >= 0 and <= 100;
        Indeterminate = e.Percentage is null;
        Color = GetColor(e.Options.Type);

        await InvokeAsync(StateHasChanged);
    }
}