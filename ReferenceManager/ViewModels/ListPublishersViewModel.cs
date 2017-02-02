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
    public class ListPublishersViewModel : BindableBase, IActiveAware
    {
        private IBookService _bookService;

        public event EventHandler IsActiveChanged;

        List<Publisher> _publishers;

        public List<Publisher> Publishers
        {
            get { return _publishers; }
            private set
            {
                SetProperty(ref _publishers, value);
            }
        }

        private bool _isActive;

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
                        Publishers = _bookService.FindPublishers();
                    }

                    IsActiveChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public ListPublishersViewModel(IBookService bookService)
        {
            _bookService = bookService;

            Publishers = _bookService.FindPublishers();
        }


    }
}
