using Reflections.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private readonly SettingsService settingsService;

    private bool isDarkMode;


    public event PropertyChangedEventHandler? PropertyChanged;


    public SettingsViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;

        IsDarkMode = settingsService.IsDarkMode;
    }


    public bool IsDarkMode
    {
        get => isDarkMode;

        set
        {
            if (isDarkMode == value)
                return;

            isDarkMode = value;

            settingsService.IsDarkMode = value;

            ApplyTheme();

            OnPropertyChanged();
        }
    }

    private void ApplyTheme()
    {
        Application.Current!.UserAppTheme =
            IsDarkMode
            ? AppTheme.Dark
            : AppTheme.Light;
    }


    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}