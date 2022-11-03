using System.Collections.Generic;
using Volo.Abp.Bundling;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.MasaTheme
{
    public class MasaThemeBundleContributor : IBundleContributor
    {
        private const string RootPathWasm = "_content/Secyud.Abp.AspNetCore.Components.WebAssembly.MasaTheme";
        public void AddScripts(BundleContext context)
        {
            context.Add($"{RootPathWasm}/scripts/lang-initializer.js");
        }

        public void AddStyles(BundleContext context)
        {
            
        }
    }
}