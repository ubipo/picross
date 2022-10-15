using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using System.Windows.Input;
using Cells;

namespace ViewModel
{
	public class MainWindowVM
	{
		public Cell<object> CurrentViewModel { get; } = Cell.Create<object>(null);

		public MainWindowVM()
		{
			var facade = new PiCrossFacade();
			CurrentViewModel.Value = new ChooseGameVM(vm => CurrentViewModel.Value = vm);
		}
	}
}
