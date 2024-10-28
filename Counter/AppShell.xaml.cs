namespace Counter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.NewCounterPage), typeof(Views.NewCounterPage));
            Routing.RegisterRoute(nameof(Views.CounterPage), typeof(Views.CounterPage));
        }
    }
}
