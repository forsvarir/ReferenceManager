using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ReferenceManager.Views;

namespace ReferenceManager
{
    public class ApplicationBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<AddAuthor>("AddAuthor");
        }
    }
}
