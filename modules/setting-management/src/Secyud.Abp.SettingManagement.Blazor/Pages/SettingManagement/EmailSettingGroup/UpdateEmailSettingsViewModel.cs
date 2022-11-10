using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Secyud.Abp.Pages.SettingManagement.EmailSettingGroup;

public class UpdateEmailSettingsViewModel
{
    [MaxLength(256)]
    [Display(Name = "SmtpHost")]
    public string SmtpHost { get; set; }

    [Range(1, 65535)]
    [Display(Name = "SmtpPort")]
    public int SmtpPort { get; set; }

    [MaxLength(1024)]
    [Display(Name = "SmtpUserName")]
    public string SmtpUserName { get; set; }

    [MaxLength(1024)]
    [DataType(DataType.Password)]
    [DisableAuditing]
    [Display(Name = "SmtpPassword")]
    public string SmtpPassword { get; set; }

    [MaxLength(1024)]
    [Display(Name = "SmtpDomain")]
    public string SmtpDomain { get; set; }

    [Display(Name = "SmtpEnableSsl")] public bool SmtpEnableSsl { get; set; }

    [Display(Name = "SmtpUseDefaultCredentials")]
    public bool SmtpUseDefaultCredentials { get; set; }

    [MaxLength(1024)]
    [Required]
    [Display(Name = "DefaultFromAddress")]
    public string DefaultFromAddress { get; set; }

    [MaxLength(1024)]
    [Required]
    [Display(Name = "DefaultFromDisplayName")]
    public string DefaultFromDisplayName { get; set; }
}