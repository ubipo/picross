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
using Utility;

namespace ViewModel
{
	public class PlayPuzzleVM
	{
		public int TotalUnknownCount { get; }
		public TimeSpan? solveTime { get; private set; } = null;
		public Cell<double> UnknownRatio { get; } = Cell.Create<double>(0);
		public Cell<bool> ContainsUnknowns { get; }
		public IGrid<PlaySquareVM> Grid { get; set; }
		public ISequence<object> RowConstraints { get; set; }
		public ISequence<object> ColumnConstraints { get; set; }
		public Cell<bool> IsSolved { get; }
		public ICommand BackCmd { get; }
		public ICommand SaveTimeCmd { get; }

		private IPuzzleLibraryEntry puzzleLibraryEntry;
		private IGameData gameData;
		private Chronometer solveChrono;
		private IPlayablePuzzle playablePuzzle;
		private Action doneCallback;
		private Action<object> setViewModel;

		public PlayPuzzleVM(Action<object> setViewModel, ref IPuzzleLibraryEntry puzzleLibraryEntry, ref IGameData gameData, Action doneCallback)
		{
			this.setViewModel = setViewModel;
			this.doneCallback = doneCallback;
			this.gameData = gameData;
			this.puzzleLibraryEntry = puzzleLibraryEntry;
			var puzzle = puzzleLibraryEntry.Puzzle;
			TotalUnknownCount = puzzle.Size.Height * puzzle.Size.Width;
			var facade = new PiCrossFacade();
			playablePuzzle = facade.CreatePlayablePuzzle(puzzle);
			Console.WriteLine(playablePuzzle.Grid.Size);
			Var<bool> lastMarkFillValue = new Var<bool>(true);
			Var<bool> lastMarkEmptyValue = new Var<bool>(true);
			this.Grid = playablePuzzle.Grid.Map(sqr => new PlaySquareVM(sqr, ref lastMarkFillValue, ref lastMarkEmptyValue)).Copy();
			this.RowConstraints = playablePuzzle.RowConstraints;
			this.ColumnConstraints = playablePuzzle.ColumnConstraints;
			this.IsSolved = playablePuzzle.IsSolved;
			this.ContainsUnknowns = playablePuzzle.ContainsUnknowns;

			playablePuzzle.UnknownCount.ValueChanged += UnknownCount_ValueChanged;
			playablePuzzle.IsSolved.ValueChanged += IsSolved_ValueChanged;

			solveChrono = new Chronometer();
			solveChrono.Start();

			this.BackCmd = new RelayCommand(Back);
			this.SaveTimeCmd = new RelayCommand(SaveTime);
		}

		private void UnknownCount_ValueChanged()
		{
			var unknownCount = playablePuzzle.UnknownCount.Value;
			var ratio = 1 - ((double)unknownCount / TotalUnknownCount);
			this.UnknownRatio.Value = ratio;
		}

		private void IsSolved_ValueChanged()
		{
			solveChrono.Tick();
			solveTime = solveChrono.TotalTime.Value;
			//IsSolved.Value = true;
		}

		public void Back()
		{
			doneCallback();
		}

		public void SaveTime()
		{
			Console.WriteLine(IsSolved.Value);
			if (IsSolved.Value)
			{
				var saveTimeVm = new SaveScoreVM(setViewModel, ref gameData, ref puzzleLibraryEntry, solveTime.Value, doneCallback);
				setViewModel(saveTimeVm);
			}
		}
	}
}
