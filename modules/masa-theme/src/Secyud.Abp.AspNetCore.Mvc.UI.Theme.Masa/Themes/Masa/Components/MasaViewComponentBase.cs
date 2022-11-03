using Volo.Abp.AspNetCore.Mvc;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Themes.Masa.Components;

public abstract class MasaViewComponentBase : AbpViewComponent
{
	protected MasaViewComponentBase()
	{
		ObjectMapperContext = typeof(AbpAspNetCoreMvcUiMasaThemeModule);
	}
}
