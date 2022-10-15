using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class PlaySquareVM
	{
		public IPlayablePuzzleSquare PuzzleSquare { get; }
		private Var<bool> prevMarkFillWasFilled;
		private Var<bool> prevMarkEmptyWasEmpty;
		public ICommand MarkFillCmd { get; }
		public ICommand MarkEmptyCmd { get; }
		public ICommand MarkFillLikeLastCmd { get; }
		public ICommand MarkEmptyLikeLastCmd { get; }

		public PlaySquareVM(IPlayablePuzzleSquare puzzleSquare, ref Var<bool> prevMarkFillWasFilled, ref Var<bool> prevMarkEmptyWasEmpty)
		{
			PuzzleSquare = puzzleSquare;
			this.prevMarkEmptyWasEmpty = prevMarkEmptyWasEmpty;
			this.prevMarkFillWasFilled = prevMarkFillWasFilled;
			MarkFillCmd = new RelayCommand(markFill);
			MarkEmptyCmd = new RelayCommand(markEmpty);
			MarkFillLikeLastCmd = new RelayCommand(markFillLikeLast);
			MarkEmptyLikeLastCmd = new RelayCommand(markEmptyLikeLast);
		}

		public void markFill()
		{
			var newValue = PuzzleSquare.Contents.Value == Square.FILLED ? Square.UNKNOWN : Square.FILLED;
			prevMarkFillWasFilled.Value = newValue == Square.FILLED;
			PuzzleSquare.Contents.Value = newValue;
		}

		public void markEmpty()
		{
			var newValue = PuzzleSquare.Contents.Value == Square.EMPTY ? Square.UNKNOWN : Square.EMPTY;
			prevMarkEmptyWasEmpty.Value = newValue == Square.EMPTY;
			PuzzleSquare.Contents.Value = newValue;
		}

		public void markFillLikeLast()
		{
			PuzzleSquare.Contents.Value = prevMarkFillWasFilled.Value ? Square.FILLED : Square.UNKNOWN;
		}

		public void markEmptyLikeLast()
		{
			PuzzleSquare.Contents.Value = prevMarkEmptyWasEmpty.Value ? Square.EMPTY : Square.UNKNOWN;
		}
	}
}
