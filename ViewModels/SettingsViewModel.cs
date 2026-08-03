using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reflections.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private bool darkModeEnabled;
    private bool notificationsEnabled;


    public event PropertyChangedEventHandler? PropertyChanged;


    public bool DarkModeEnabled
    {
        get => darkModeEnabled;

        set
        {
            darkModeEnabled = value;
            OnPropertyChanged();
        }
    }


    public bool NotificationsEnabled
    {
        get => notificationsEnabled;

        set
        {
            notificationsEnabled = value;
            OnPropertyChanged();
        }
    }


    public string AppVersion =>
        "Version 1.0";


    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}