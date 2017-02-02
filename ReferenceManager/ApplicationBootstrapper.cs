using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ReferenceManager.Views;
using ReferenceManager.Services;

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

            Container.RegisterInstance<IBookService>(new BookService());

            Container.RegisterTypeForNavigation<AddAuthor>("AddAuthor");
            Container.RegisterTypeForNavigation<ListAuthors>();
            Container.RegisterTypeForNavigation<AddLocation>();
            Container.RegisterTypeForNavigation<ListLocations>();
            Container.RegisterTypeForNavigation<AddPublisher>();
            Container.RegisterTypeForNavigation<ListPublishers>();
        }
    }
}
