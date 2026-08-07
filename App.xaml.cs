namespace Reflections
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
        protected override void OnStart()
        {
            base.OnStart();

            ApplySavedTheme();
        }


        private void ApplySavedTheme()
        {
            bool darkMode = Preferences.Get(
                "dark_mode",
                false);

            UserAppTheme = darkMode
                ? AppTheme.Dark
                : AppTheme.Light;
        }
    }
}