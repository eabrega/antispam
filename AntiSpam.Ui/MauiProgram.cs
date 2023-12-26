using AntiSpam.Applications.PhoneNumberCheckers;
using AntiSpam.Core.Callers;
using AntiSpam.Core.Events;
using AntiSpam.Core.Handlers;
using AntiSpam.Database;
using AntiSpam.Infrastructure.Repositories;
using AntiSpam.Ui.Devices;
using AntiSpam.Ui.Pages;
using AntiSpam.Ui.ViewModels;
using AntiSpam.Ui.ViewModels.SettingsViewModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
//using Microsoft.Maui.Handlers;
namespace AntiSpam.Ui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit(options =>
            {
                options.SetShouldSuppressExceptionsInConverters(false);
                options.SetShouldSuppressExceptionsInBehaviors(false);
                options.SetShouldSuppressExceptionsInAnimations(false);
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            });

        //        EntryHandler.Mapper.AppendToMapping(nameof(EntryCell), (handler, view) =>
        //        {
        //#if ANDROID
        //            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        //#endif
        //        });

        //        PickerHandler.Mapper.AppendToMapping(nameof(EntryCell), (handler, view) =>
        //        {
        //#if ANDROID
        //            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        //#endif
        //        });

        //        EditorHandler.Mapper.AppendToMapping(nameof(EntryCell), (handler, view) =>
        //        {
        //#if ANDROID
        //            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        //#endif
        //        });


#if DEBUG        
        builder.Logging.AddDebug();
        builder.Services.AddSingleton<ILoggerProvider, LogcatProvider>();
#endif
        builder.Services.AddScoped<IMessenger, WeakReferenceMessenger>();

        builder.Services.AddSingleton<IDeviceController, DeviceController>();
        builder.Services.AddSingleton<IPermissionController, PermissionController>();

        builder.Services.AddScoped<CallersContext>();
        builder.Services.AddScoped<ICallersRepository, CallersRepository>();

        builder.Services.AddScoped<IPhoneNumberChecker, PhoneNumberChecker>();

        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddSingleton<CallerEditor,  CallerEditorViewModel>();
        builder.Services.AddTransient<Callers, CallersViewModel>();
        builder.Services.AddSingleton<Home, HomeViewModel>();
        builder.Services.AddSingleton<Settings, SettingsViewModel>();

        builder.Services.AddSingleton<CallerDetails>();

        builder.Services.AddScoped<IEventPublisher, EventPublisher>();
        builder.Services.RegisterDomainEventHandlers();

        return builder.Build();
    }
}
