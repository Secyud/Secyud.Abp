using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent;
using Force.DeepCloner;
using JetBrains.Annotations;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.Authorization;

namespace Secyud.Abp.MasaBlazorUi;

public abstract class AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey>
    : AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        PagedAndSortedResultRequestDto>
    where TAppService : ICrudAppService<
        TEntityDto,
        TKey>
    where TEntityDto : class, IEntityDto<TKey>, new()
{
}

public abstract class AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput>
    : AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput,
        TEntityDto>
    where TAppService : ICrudAppService<
        TEntityDto,
        TKey,
        TGetListInput>
    where TEntityDto : class, IEntityDto<TKey>, new()
    where TGetListInput : new()
{
}

public abstract class AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput>
    : AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TCreateInput>
    where TAppService : ICrudAppService<
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput>
    where TEntityDto : IEntityDto<TKey>
    where TCreateInput : class, new()
    where TGetListInput : new()
{
}

public abstract class AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    : AbpCrudPageBase<
        TAppService,
        TEntityDto,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    where TAppService : ICrudAppService<
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    where TEntityDto : IEntityDto<TKey>
    where TCreateInput : class, new()
    where TUpdateInput : class, new()
    where TGetListInput : new()
{
}

public abstract class AbpCrudPageBase<
        TAppService,
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    : AbpCrudPageBase<
        TAppService,
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput,
        TGetListOutputDto,
        TCreateInput,
        TUpdateInput>
    where TAppService : ICrudAppService<
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
    where TCreateInput : class, new()
    where TUpdateInput : class, new()
    where TGetListInput : new()
{
}

public abstract class AbpCrudPageBase<
        TAppService,
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput,
        TListViewModel,
        TCreateViewModel,
        TUpdateViewModel>
    : AbpComponentBase
    where TAppService : ICrudAppService<
        TGetOutputDto,
        TGetListOutputDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
    where TCreateInput : class
    where TUpdateInput : class
    where TGetListInput : new()
    where TListViewModel : IEntityDto<TKey>
    where TCreateViewModel : class, new()
    where TUpdateViewModel : class, new()
{
    [Inject] protected TAppService AppService { get; set; }
    [Inject] protected IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }

    protected string ActionColName => MasaBlazorUiConsts.ActionColName;
    
    protected int ItemsPerPage  = LimitedResultRequestDto.DefaultMaxResultCount;
    protected int Page = 1;
    protected string Sorting;
    protected int TotalCount;
    protected readonly TGetListInput GetListInput = new();
    protected IReadOnlyList<TListViewModel> Entities = Array.Empty<TListViewModel>();
    protected TCreateViewModel NewEntity = new();
    protected TKey EditingEntityId;
    protected TUpdateViewModel EditingEntity = new();
    protected bool CreateModalVisible;
    protected bool EditModalVisible;
    protected List<BreadcrumbItem> BreadcrumbItems = new(2);
    protected EntityActionDictionary EntityActions { get; set; } = new();
    protected TableHeaderDictionary<TListViewModel> TableHeaders { get; set; } = new();

    protected string CreatePolicyName { get; set; } = null;
    protected string UpdatePolicyName { get; set; }= null;
    protected string DeletePolicyName { get; set; }= null;

    public bool HasCreatePermission { get; set; }
    public bool HasUpdatePermission { get; set; }
    public bool HasDeletePermission { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await SetPermissionsAsync();
        await SetEntityActionsAsync();
        await SetTableHeadersAsync();
        await SetToolbarItemsAsync();
        await SetBreadcrumbItemsAsync();
        await GetEntitiesAsync();
    }

    protected virtual async Task SetPermissionsAsync()
    {
        if (CreatePolicyName != null)
            HasCreatePermission = await AuthorizationService.IsGrantedAsync(CreatePolicyName);

        if (UpdatePolicyName != null)
            HasUpdatePermission = await AuthorizationService.IsGrantedAsync(UpdatePolicyName);

        if (DeletePolicyName != null)
            HasDeletePermission = await AuthorizationService.IsGrantedAsync(DeletePolicyName);
    }

    protected virtual async Task GetEntitiesAsync()
    {
        try
        {
            await UpdateGetListInputAsync();
            var result = await AppService.GetListAsync(GetListInput);
            Entities = MapToListViewModel(result.Items);
            TotalCount = (int)result.TotalCount;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    private IReadOnlyList<TListViewModel> MapToListViewModel(IReadOnlyList<TGetListOutputDto> dtos)
    {
        if (typeof(TGetListOutputDto) == typeof(TListViewModel))
            return dtos.As<IReadOnlyList<TListViewModel>>();

        return ObjectMapper.Map<IReadOnlyList<TGetListOutputDto>, List<TListViewModel>>(dtos);
    }

    protected virtual Task UpdateGetListInputAsync()
    {
        if (GetListInput is ISortedResultRequest sortedResultRequestInput)
            sortedResultRequestInput.Sorting = Sorting;

        if (GetListInput is IPagedResultRequest pagedResultRequestInput)
            pagedResultRequestInput.SkipCount = (Page - 1) * ItemsPerPage;

        if (GetListInput is ILimitedResultRequest limitedResultRequestInput)
            limitedResultRequestInput.MaxResultCount = ItemsPerPage;

        return Task.CompletedTask;
    }

    protected virtual async Task OnOptionsUpdateAsync(DataOptions dataOptions)
    {
        Page = dataOptions.Page;
        ItemsPerPage = dataOptions.ItemsPerPage;

        var sort = dataOptions.SortBy.Select(u=>u.ShallowClone()).ToArray();
        for (var i = 0; i < sort.Length; i++)
            if (dataOptions.SortDesc[i])
                sort[i] += " DESC";
        Sorting = sort.JoinAsString(",");
        
        await GetEntitiesAsync();

        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OpenCreateModalAsync()
    {
        try
        {
            await CheckCreatePolicyAsync();

            NewEntity = new TCreateViewModel();

            await InvokeAsync(() =>
            {
                CreateModalVisible = true;
                StateHasChanged();
            });
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual Task CloseCreateModalAsync()
    {
        NewEntity = new TCreateViewModel();
        return InvokeAsync(() => CreateModalVisible = false);
    }

    protected virtual async Task OpenEditModalAsync(TListViewModel entity)
    {
        try
        {
            await CheckUpdatePolicyAsync();

            var entityDto = await AppService.GetAsync(entity.Id);

            EditingEntityId = entity.Id;
            EditingEntity = MapToEditingEntity(entityDto);

            await InvokeAsync( () =>
            {
                EditModalVisible = true;
                StateHasChanged();
            });
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual TUpdateViewModel MapToEditingEntity(TGetOutputDto entityDto)
    {
        return ObjectMapper.Map<TGetOutputDto, TUpdateViewModel>(entityDto);
    }

    protected virtual TCreateInput MapToCreateInput(TCreateViewModel createViewModel)
    {
        return typeof(TCreateInput) == typeof(TCreateViewModel) ? 
            createViewModel.As<TCreateInput>() : 
            ObjectMapper.Map<TCreateViewModel, TCreateInput>(createViewModel);
    }

    protected virtual TUpdateInput MapToUpdateInput(TUpdateViewModel updateViewModel)
    {
        return typeof(TUpdateInput) == typeof(TUpdateViewModel) ? 
            updateViewModel.As<TUpdateInput>() :
            ObjectMapper.Map<TUpdateViewModel, TUpdateInput>(updateViewModel);
    }

    protected virtual Task CloseEditModalAsync()
    {
        InvokeAsync(() => EditModalVisible = false);
        return Task.CompletedTask;
    }

    protected virtual async Task CreateEntityAsync()
    {
        try
        {
            await OnCreatingEntityAsync();

            await CheckCreatePolicyAsync();
            var createInput = MapToCreateInput(NewEntity);
            await AppService.CreateAsync(createInput);

            await OnCreatedEntityAsync();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual Task OnCreatingEntityAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual async Task OnCreatedEntityAsync()
    {
        NewEntity = new TCreateViewModel();
        await GetEntitiesAsync();

        await CloseCreateModalAsync();
    }

    protected virtual async Task UpdateEntityAsync()
    {
        try
        {
            await OnUpdatingEntityAsync();

            await CheckUpdatePolicyAsync();
            var updateInput = MapToUpdateInput(EditingEntity);
            await AppService.UpdateAsync(EditingEntityId, updateInput);

            await OnUpdatedEntityAsync();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual Task OnUpdatingEntityAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual async Task OnUpdatedEntityAsync()
    {
        await GetEntitiesAsync();

        await CloseEditModalAsync();
    }

    protected virtual async Task DeleteEntityAsync(TListViewModel entity)
    {
        try
        {
            await CheckDeletePolicyAsync();
            await OnDeletingEntityAsync();
            await AppService.DeleteAsync(entity.Id);
            await OnDeletedEntityAsync();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual Task OnDeletingEntityAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual async Task OnDeletedEntityAsync()
    {
        await GetEntitiesAsync();
        await InvokeAsync(StateHasChanged);
        await Notify.Success(L["SuccessfullyDeleted"]);
    }

    protected virtual string GetDeleteConfirmationMessage(TListViewModel entity)
    {
        return UiLocalizer["ItemWillBeDeletedMessage"];
    }

    protected virtual async Task CheckCreatePolicyAsync()
    {
        await CheckPolicyAsync(CreatePolicyName);
    }

    protected virtual async Task CheckUpdatePolicyAsync()
    {
        await CheckPolicyAsync(UpdatePolicyName);
    }

    protected virtual async Task CheckDeletePolicyAsync()
    {
        await CheckPolicyAsync(DeletePolicyName);
    }

    /// <summary>
    /// Calls IAuthorizationService.CheckAsync for the given <paramref name="policyName"/>.
    /// Throws <see cref="AbpAuthorizationException"/> if given policy was not granted for the current user.
    ///
    /// Does nothing if <paramref name="policyName"/> is null or empty.
    /// </summary>
    /// <param name="policyName">A policy name to check</param>
    protected virtual async Task CheckPolicyAsync([CanBeNull] string policyName)
    {
        if (string.IsNullOrEmpty(policyName))
            return;

        await AuthorizationService.CheckAsync(policyName);
    }

    protected virtual ValueTask SetBreadcrumbItemsAsync()
    {
        return ValueTask.CompletedTask;
    }

    protected virtual ValueTask SetEntityActionsAsync()
    {
        return ValueTask.CompletedTask;
    }

    protected virtual ValueTask SetTableHeadersAsync()
    {
        return ValueTask.CompletedTask;
    }

    protected virtual ValueTask SetToolbarItemsAsync()
    {
        return ValueTask.CompletedTask;
    }
}
