using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa;

[ThemeName(Name)]
public class MasaTheme : ITheme, ITransientDependency
{
	public const string Name = "Masa";

	private readonly IConfiguration _configuration;
	private readonly MasaThemeMvcOptions _options;

	public MasaTheme(IConfiguration configuration, IOptions<MasaThemeMvcOptions> options)
	{
		_configuration = configuration;
		_options = options.Value;
	}

	public virtual string GetLayout(string name, bool fallbackToDefault = true)
	{
		switch (name)
		{
			case StandardLayouts.Application:
				return GetLayoutFromConfig("Application") ?? _options.ApplicationLayout;
			case StandardLayouts.Account:
				return GetLayoutFromConfig("Account") ?? "~/Themes/Masa/Layouts/Account/Default.cshtml";
			case StandardLayouts.Public:
				return GetLayoutFromConfig("Public") ?? _options.ApplicationLayout; // No-public layout yet
			case StandardLayouts.Empty:
				return GetLayoutFromConfig("Empty") ?? "~/Themes/Masa/Layouts/Empty/Default.cshtml";
			default:
				return fallbackToDefault ? "~/Themes/Masa/Layouts/Application/Default.cshtml" : null;
		}
	}

	private string GetLayoutFromConfig(string layoutName)
	{
		return _configuration["MasaTheme:Layouts:" + layoutName];
	}
}
