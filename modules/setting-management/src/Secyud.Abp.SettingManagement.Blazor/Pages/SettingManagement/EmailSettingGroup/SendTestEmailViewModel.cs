using System.ComponentModel.DataAnnotations;

namespace Secyud.Abp.Pages.SettingManagement.EmailSettingGroup;

public class SendTestEmailViewModel
{
    [Required] public string SenderEmailAddress { get; set; }

    [Required] public string TargetEmailAddress { get; set; }

    [Required] public string Subject { get; set; }

    public string Body { get; set; }
}