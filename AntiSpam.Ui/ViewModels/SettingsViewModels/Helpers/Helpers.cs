using AntiSpam.Ui.ViewModels.SettingsViewModels.Models;

namespace AntiSpam.Ui.ViewModels.SettingsViewModels.Helpers
{
    internal static class Helpers
    {
        internal static async Task<bool> GetPermissionByCategory(
            this IPermissionController permissionController,
            PermissionCategory category) => category switch
            {
                PermissionCategory.Contact => await permissionController.RequestContactPermission(),
                PermissionCategory.Phone => await permissionController.RequestPhonePermission(),
                PermissionCategory.CallLog => await permissionController.RequestCallLogPermission(),
                PermissionCategory.Dialler => permissionController.CheckDefaultDiallerStatus(),
                _ => throw new NotImplementedException()
            };
    }
}
