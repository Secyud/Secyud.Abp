using AutoMapper;
using Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Navigation;
using Volo.Abp.AutoMapper;
using Volo.Abp.UI.Navigation;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.ObjectMapping
{
    public class MasaThemeAutoMapperProfile : Profile
    {
        public MasaThemeAutoMapperProfile()
        {
            CreateMap<ApplicationMenu, MenuViewModel>()
                .ForMember(vm => vm.Menu, cnf => cnf.MapFrom(x => x));

            CreateMap<ApplicationMenuItem, MenuItemViewModel>()
                .ForMember(vm => vm.MenuItem, cnf => cnf.MapFrom(x => x))
                .Ignore(vm => vm.IsActive)
                .Ignore(vm => vm.IsInRoot);
        }
    }
}
