using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using BirthdayReminder.ViewModels;
using BirthdayReminder.Views;

namespace BirthdayReminder;

public partial class App : Application
{
    private WindowController _windowController;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _windowController = new WindowController();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };


        }

        base.OnFrameworkInitializationCompleted();
    }
}