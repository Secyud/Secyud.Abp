window.afterMasaInitialization = function () {

    console.log("afterMasaInitialization");
    var isRtl = JSON.parse(localStorage.getItem("Abp.IsRtl"));
    var direction = isRtl ? "rtl" : "ltr";

    replaceStyleWith(
        createStyleUrl('layout-bundle', direction),
        `masa-layout-bundle-style-${direction}`,
        `masa-layout-bundle-style-${direction === 'rtl' ? 'ltr' : 'rtl'}`
    );
    replaceStyleWith(
        createStyleUrl('abp-bundle', direction),
        `masa-abp-bundle-style-${direction}`,
        `masa-abp-bundle-style-${direction === 'rtl' ? 'ltr' : 'rtl'}`
    );
    replaceStyleWith(
        createStyleUrl('blazor-bundle', direction),
        `masa-blazor-bundle-style-${direction}`,
        `masa-blazor-bundle-style-${direction === 'rtl' ? 'ltr' : 'rtl'}`
    );


    function createStyleUrl(theme, direction = 'ltr') {
        const styleName = direction === 'rtl' ? `${theme}.rtl` : theme;
        return `/_content/Volo.Abp.AspNetCore.Components.Web.MasaTheme/${window.currentLayout}/css/${styleName}.css`
    }

    function createId(theme, type) {
        return theme && `masa-theme-${type}-${theme}`;
    }

    function replaceStyleWith(path, id, previousId) {
        const link = document.createElement('link');
        link.href = path;
        link.type = 'text/css';
        link.rel = 'stylesheet';
        link.id = id;
        const prevElem = document.querySelector(`#${previousId}`);
        document.getElementsByTagName('head')[0].appendChild(link);
        if (previousId) {
            prevElem?.remove();
        }
        return link;
    }

    function loadThemeCSS(key, theme, themeOld, cssPrefix, direction = 'ltr') {
        const themeId = createId(theme, key);
        const previousThemeId = createId(themeOld, key);

        replaceStyleWith(createStyleUrl(cssPrefix + theme, direction), themeId, previousThemeId);
    }
};