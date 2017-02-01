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
    public class ListAuthorsViewModel : BindableBase, IActiveAware
    {
        private IBookService _bookService;

        public event EventHandler IsActiveChanged;

        List<Author> _authors;

        public List<Author> Authors { get { return _authors; } private set {
                SetProperty(ref _authors, value);
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
                if(_isActive != value)
                {
                    _isActive = value;

                    if (_isActive)
                    {
                        Authors = _bookService.FindAuthors();
                    }
                }
            }
        }

        public ListAuthorsViewModel(IBookService bookService)
        {
            _bookService = bookService;

            Authors = _bookService.FindAuthors();
        }


    }
}
