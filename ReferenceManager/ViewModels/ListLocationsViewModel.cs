using Prism;
using Prism.Mvvm;
using ReferenceManager.DAL;
using ReferenceManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceManager.ViewModels
{
    class ListLocationsViewModel : BindableBase, IActiveAware
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
                        Locations = _bookService.FindLocations();
                    }

                    IsActiveChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler IsActiveChanged;

        List<Location> _locations;

        public List<Location> Locations
        {
            get { return _locations; }
            private set
            {
                SetProperty(ref _locations, value);
            }
        }


        public ListLocationsViewModel(IBookService bookService)
        {
            _bookService = bookService;

            Locations = _bookService.FindLocations();
        }


    }
}
