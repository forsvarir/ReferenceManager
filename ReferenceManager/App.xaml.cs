using System.Windows;

namespace ReferenceManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationBootstrapper bootstrapper = new ApplicationBootstrapper();
            bootstrapper.Run();
        }
    }
}
