using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web.Configuration;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Secyud.Abp.Components.FeatureManagement;

public partial class FeatureManagementModal
{
    protected readonly UpdateFeaturesDto Features = new();

    protected bool ModalVisible;
    protected string ProviderKey;

    protected string ProviderName;

    protected StringNumber SelectedTabName;

    protected Dictionary<string, string> SelectionStringValues;

    protected Dictionary<string, bool> ToggleValues;
    [Inject] protected IFeatureAppService AppService { get; set; }

    [Inject] protected IUiMessageService UiMessageService { get; set; }

    [Inject] protected IStringLocalizerFactory HtmlLocalizerFactory { get; set; }

    [Inject] protected IOptions<AbpLocalizationOptions> LocalizationOptions { get; set; }

    [Inject] protected ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService { get; set; }

    protected List<FeatureGroupDto> Groups { get; set; }

    public virtual async Task OpenAsync([NotNull] string providerName, string providerKey = null)
    {
        try
        {
            ProviderName = providerName;
            ProviderKey = providerKey;

            ToggleValues = new Dictionary<string, bool>();
            SelectionStringValues = new Dictionary<string, string>();

            var result = await AppService.GetAsync(ProviderName, ProviderKey);

            Groups = result?.Groups ?? new List<FeatureGroupDto>();

            if (Groups.Any()) SelectedTabName = GetNormalizedGroupName(Groups.First().Name);

            foreach (var featureGroupDto in Groups)
            foreach (var featureDto in featureGroupDto.Features)
            {
                if (featureDto.ValueType is ToggleStringValueType) ToggleValues.Add(featureDto.Name, bool.Parse(featureDto.Value));

                if (featureDto.ValueType is SelectionStringValueType) SelectionStringValues.Add(featureDto.Name, featureDto.Value);
            }

            ModalVisible = true;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    public virtual Task CloseModal()
    {
        return InvokeAsync(() => ModalVisible = false);
    }

    protected virtual async Task SaveAsync()
    {
        try
        {
            Features.Features = Groups.SelectMany(g => g.Features).Select(f => new UpdateFeatureDto
            {
                Name = f.Name,
                Value = f.ValueType switch
                {
                    ToggleStringValueType => ToggleValues[f.Name].ToString(),
                    SelectionStringValueType => SelectionStringValues[f.Name],
                    _ => f.Value
                }
            }).ToList();

            await AppService.UpdateAsync(ProviderName, ProviderKey, Features);

            await CurrentApplicationConfigurationCacheResetService.ResetAsync();

            await CloseModal();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual string GetNormalizedGroupName(string name)
    {
        return "FeatureGroup_" + name.Replace(".", "_");
    }

    protected virtual string GetFeatureStyles(FeatureDto feature)
    {
        return $"margin-left: {feature.Depth * 20}px";
    }

    protected virtual bool IsDisabled(string providerName)
    {
        return providerName != ProviderName && providerName != DefaultValueFeatureValueProvider.ProviderName;
    }

    protected virtual async Task OnFeatureValueChangedAsync(string value, FeatureDto feature)
    {
        if (feature?.ValueType?.Validator.IsValid(value) == true)
            feature.Value = value;
        else
            await UiMessageService.Warn(L["Volo.Abp.FeatureManagement:InvalidFeatureValue", feature!.DisplayName]);
    }

    protected virtual Task OnSelectedValueChangedAsync(bool value, FeatureDto feature)
    {
        ToggleValues[feature.Name] = value;

        if (value)
            CheckParents(feature.ParentName);
        else
            UncheckChildren(feature.Name);

        return Task.CompletedTask;
    }

    protected virtual void CheckParents(string parentName)
    {
        if (parentName.IsNullOrWhiteSpace()) return;

        foreach (var featureGroupDto in Groups)
        foreach (var featureDto in featureGroupDto.Features)
            if (featureDto.Name == parentName && ToggleValues.ContainsKey(featureDto.Name))
            {
                ToggleValues[featureDto.Name] = true;
                CheckParents(featureDto.ParentName);
            }
    }

    protected virtual void UncheckChildren(string featureName)
    {
        foreach (var featureGroupDto in Groups)
        foreach (var featureDto in featureGroupDto.Features)
            if (featureDto.ParentName == featureName && ToggleValues.ContainsKey(featureDto.Name))
            {
                ToggleValues[featureDto.Name] = false;
                UncheckChildren(featureDto.Name);
            }
    }

    protected virtual IStringLocalizer CreateStringLocalizer(string resourceName)
    {
        var resource = LocalizationOptions
            .Value
            .Resources
            .Values
            .FirstOrDefault(x => x.ResourceName == resourceName);
        return HtmlLocalizerFactory
            .Create(resource != null ? resource.ResourceType : LocalizationOptions.Value.DefaultResourceType);
    }
}