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
    public class AddLocationViewModel : BindableBase
    {
        private string _status;
        private string _quickName;
        private string _room;
        private string _shelf;
        private IBookService _bookService;

        public string QuickName
        {
            get { return _quickName; }
            set {
                SetProperty(ref _quickName, value);
                ResetStatus();
            }
        }

        public string Room
        {
            get { return _room; }
            set {
                SetProperty(ref _room, value);
                ResetStatus();
            }
        }

        public string Shelf
        {
            get { return _shelf; }
            set {
                SetProperty(ref _shelf, value);
                ResetStatus();
            }
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }


        public AddLocationViewModel(IBookService bookSevice)
        {
            _bookService = bookSevice;
            AddCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => QuickName).ObservesProperty(()=>Room).ObservesProperty(()=>Shelf);
        }

        public DelegateCommand AddCommand { get; private set; }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(_quickName) && !string.IsNullOrWhiteSpace(_room) && !string.IsNullOrWhiteSpace(_shelf);
        }

        private void Execute()
        {
            _bookService.AddLocation(new DAL.Location { QuickName = _quickName, Room=_room, Shelf=_shelf });
            Status = "Added.";
        }

        private void ResetStatus()
        {
            Status = "";
        }
    }
}
