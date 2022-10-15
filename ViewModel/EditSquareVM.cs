using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class EditSquareVM
	{
		public Cell<bool> Square { get; private set; }
		public ICommand Mark { get; }
		public ICommand Print { get; }

		public EditSquareVM(bool square)
		{
			this.Square = Cell.Create(square);
			Mark = new RelayCommand(o => {
				this.Square.Value = !this.Square.Value;
				Console.WriteLine(this.Square.Value);
			});

			this.Print = new RelayCommand(o =>
			{
				Console.WriteLine(this.Square.Value);
			});
		}
	}
}
