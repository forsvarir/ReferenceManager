using Prism.Commands;
using Prism.Mvvm;
using ReferenceManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceManager.ViewModels
{
    public class AddAuthorViewModel : BindableBase
    {
        private string _name = null;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                ResetStatus();
            }
        }

        private void ResetStatus()
        {
            Status = "";
        }

        public string _status = null;
        private IBookService _bookService;

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public DelegateCommand AddCommand { get; private set; }

        public AddAuthorViewModel(IBookService bookService)
        {
            _bookService = bookService;
            AddCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Name);
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(_name);
        }

        private void Execute()
        {
            _bookService.AddAuthor(new DAL.Author { Name = _name });
            Status = "Added.";
        }
    }
}
