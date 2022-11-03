(function () {

    function isAlreadyLoaded(id) {
        return document.querySelector(`link[id^="masa-theme-${id}-"]`)?.id;
    }
  
    function loadThemeCSS(key, event, cssPrefix) {
        const newThemeId = createId(event.detail.theme, key);
        const previousThemeId = createId(event.detail.previousTheme, key);
        const loadedCSS = isAlreadyLoaded(key);
  
        if (newThemeId !== loadedCSS) {
            Masa.replaceStyleWith(
                createStyleUrl(cssPrefix + event.detail.theme),
                newThemeId,
                previousThemeId || loadedCSS
            );
        }
      }

    function createId(theme, type) {
        return theme && `masa-theme-${type}-${theme}`;
    }

    Masa.CSSLoadEvent.on(event => {
        loadThemeCSS('bootstrap', event, 'bootstrap-');
        loadThemeCSS('color', event, '');
    });

    window.initMasa = function (layout = currentLayout) {
        currentLayout = layout;
        Masa.CSSLoadEvent.on(event => {
            loadThemeCSS('bootstrap', event, 'bootstrap-');
            loadThemeCSS('color', event, '');
        });

        Masa.init.run();
    }

    function createStyleUrl(theme, type) {

        if (isRtl()) {
            theme = theme + '.rtl';
        }
        
        if (type) {
            return `/Themes/Masa/Global/${currentLayout}/css/${type}-${theme}.css`;
        }
        return `/Themes/Masa/Global/${currentLayout}/css/${theme}.css`;
    }

    function isRtl() {
        return document.documentElement.getAttribute('dir') === 'rtl';
    }
})();