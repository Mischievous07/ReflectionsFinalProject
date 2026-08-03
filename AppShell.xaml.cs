namespace Reflections;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.EntryDetailPage),
            typeof(Views.EntryDetailPage));
        Routing.RegisterRoute(nameof(Views.NewEntryPage), 
            typeof(Views.NewEntryPage));
    }
}