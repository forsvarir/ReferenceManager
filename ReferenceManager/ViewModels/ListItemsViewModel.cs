using Prism;
using Prism.Mvvm;
using Prism.Regions;
using ReferenceManager.DAL;
using ReferenceManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceManager.ViewModels
{
    class ColumnDescriptor
    {
        public string HeaderText { get; set; }
        public string DisplayMember { get; set; }
    }

    class ListItemsViewModel : BindableBase, IActiveAware, INavigationAware
    {
        private bool _isActive;
        private IBookService _bookService;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }

            set
            {
                if (_isActive != value)
                {
                    _isActive = value;

                    if (_isActive)
                    {
                        Items = _bookService.FindLocations();
                    }

                    IsActiveChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler IsActiveChanged;

        object _items;

        public object Items
        {
            get { return _items; }
            private set
            {
                SetProperty(ref _items, value);
            }
        }

        public ObservableCollection<ColumnDescriptor> ColumnDefinitions { get; private set; }

        public ListItemsViewModel(IBookService bookService)
        {
            this.ColumnDefinitions = new ObservableCollection<ColumnDescriptor>();

            _bookService = bookService;

        }

        private void SetupColumnDefinitions(Type dataType)
        {
            ColumnDefinitions.Clear();
            foreach (var property in dataType.GetProperties())
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                ColumnDefinitions.Add(new ColumnDescriptor { HeaderText = null == attribute ? property.Name : attribute.DisplayName, DisplayMember = property.Name });
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var contentType = navigationContext.Parameters["contentType"] as string;
            switch(contentType)
            {
                case "Author":
                    Items = _bookService.FindAuthors();
                    SetupColumnDefinitions(typeof(Author));
                    break;
                case "Location":
                    Items = _bookService.FindLocations();
                    SetupColumnDefinitions(typeof(Location));
                    break;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Console.WriteLine(navigationContext.Uri);
        }
    }
}
