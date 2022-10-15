using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class EditPuzzleVM
	{
		public IGrid<EditSquareVM> Grid { get; private set; }
		public ICommand Save { get; }

		private Action<Puzzle> SaveCallback { get; set; }

		public EditPuzzleVM(Action<object> setViewModel, Puzzle puzzle, Action<Puzzle> saveCallback)
		{
			this.SaveCallback = saveCallback;
			this.Grid = puzzle.Grid.Map(s => new EditSquareVM(s)).Copy();

			this.Save = new RelayCommand(o =>
			{
				var newPuzzle = Puzzle.FromGrid(this.Grid.Map(s => Square.FromBool(s.Square.Value)));
				this.SaveCallback.Invoke(newPuzzle);
			});
		}
	}
}
