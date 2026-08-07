namespace Reflections.Services;

public class SettingsService
{
    private const string DarkModeKey = "dark_mode";


    public bool IsDarkMode
    {
        get
        {
            return Preferences.Get(
                DarkModeKey,
                false);
        }

        set
        {
            Preferences.Set(
                DarkModeKey,
                value);
        }
    }
}