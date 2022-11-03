using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Secyud.Abp.MasaTheme.Shared;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa;

public class MasaStyleProvider : ITransientDependency
{
	private const string Masa_STYLE_COOKIE_NAME = "masa_loaded-css";

	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly MasaThemeOptions _MasaThemeOption;

	public MasaStyleProvider(IHttpContextAccessor httpContextAccessor, IOptions<MasaThemeOptions> MasaThemeOption)
	{
		_httpContextAccessor = httpContextAccessor;
		_MasaThemeOption = MasaThemeOption.Value;
	}

	public Task<string> GetSelectedStyleAsync()
	{
		var styleName = _httpContextAccessor.HttpContext?.Request.Cookies[Masa_STYLE_COOKIE_NAME];

		if (string.IsNullOrWhiteSpace(styleName) || !_MasaThemeOption.Styles.ContainsKey(styleName))
		{
			return Task.FromResult(_MasaThemeOption.DefaultStyle);
		}

		return Task.FromResult(styleName);
	}
}
