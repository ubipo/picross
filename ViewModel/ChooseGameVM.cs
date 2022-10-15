using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class ChooseGameVM
	{
		public Cell<ObservableCollection<PuzzleEntryWrapper>> PuzzleEntries { get; set; } = Cell.Create<ObservableCollection<PuzzleEntryWrapper>>(null);
		public Cell<PuzzleEntryWrapper> Selection { get; set; } = Cell.Create<PuzzleEntryWrapper>(null);
		public string CreateWidth { get; set; }
		public string CreateHeight { get; set; }
		public string CreateAuthor { get; set; }
		public Cell<string> CreateErr { get; private set; } = Cell.Create<string>(null);
		public ICommand PlayCmd { get; }
		public ICommand EditCmd { get; }
		public ICommand CreateCmd { get; }
		public ICommand DeleteLibCmd { get; }
		public ICommand PopulateLibCmd { get; }

		private Action<object> SetViewModel { get; set; }
		private IGameData gameData;

		public ChooseGameVM(Action<object> setViewModel)
		{
			SetViewModel = setViewModel;
			initGameData();
			PlayCmd = new RelayCommand(play);
			EditCmd = new RelayCommand(edit);
			CreateCmd = new RelayCommand(create);
			DeleteLibCmd = new RelayCommand(DeleteLib);
			PopulateLibCmd = new RelayCommand(PopulateLib);
		}

		private void initGameData()
		{
			var facade = new PiCrossFacade();
			gameData = facade.LoadGameData(gameDataFilePath, createIfNotExistent: true);
			PuzzleEntries.Value = new ObservableCollection<PuzzleEntryWrapper>(gameData.PuzzleLibrary.Entries.Select(ple => new PuzzleEntryWrapper(ple, play)));
		}

		private String gameDataFilePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"pipipu_gamedata.dat"
		);

		public void play()
		{
			var puzzleLibraryEntry = Selection.Value.PuzzleLibraryEntry;
			SetViewModel(new PlayPuzzleVM(SetViewModel, ref puzzleLibraryEntry, ref gameData, () => {
				SetViewModel(this);
			}));
		}

		public void edit()
		{
			var entry = Selection.Value.PuzzleLibraryEntry;
			SetViewModel(new EditPuzzleVM(SetViewModel, entry.Puzzle, newPuzzle => {
				entry.Puzzle = newPuzzle;
				SetViewModel(this);
			}));
		}

		public void create()
		{
			CreateErr.Value = null;
			if (!int.TryParse(CreateWidth, out int width) || !(width > 0 && width <= 100))
			{
				CreateErr.Value = String.Format("Width \"{0}\" is not valid (must be an integer between 0 and 100 exclusive)", CreateWidth);
				Console.WriteLine(width);
				Console.WriteLine(!(width > 0 && width <= 100));
				return;
			}

			if (!int.TryParse(CreateHeight, out int height) || !(height > 0 && height <= 100))
			{
				CreateErr.Value = String.Format("Height \"{0}\" is not valid (must be an integer between 0 and 100 exclusive)", CreateHeight);
				return;
			}

			string author = CreateAuthor;
			if (String.IsNullOrWhiteSpace(author))
			{
				CreateErr.Value = String.Format("Author cannot be only white spaces", author);
				return;
			}

			var puzzleEntry = gameData.PuzzleLibrary.Create(Puzzle.CreateEmpty(new Size(width, height)), author);
			var wrappedEntry = new PuzzleEntryWrapper(puzzleEntry, play);
			PuzzleEntries.Value.Add(wrappedEntry);
			Selection.Value = wrappedEntry;
			edit();
		}

		public void DeleteLib()
		{
			if (File.Exists(gameDataFilePath))
			{
				File.Delete(gameDataFilePath);
			}
			initGameData();
		}

		public void PopulateLib()
		{
			var facade = new PiCrossFacade();
			var dummyData = facade.CreateDummyGameData();
			foreach (IPuzzleLibraryEntry entry in dummyData.PuzzleLibrary.Entries)
			{
				var newEntry = gameData.PuzzleLibrary.Create(entry.Puzzle, entry.Author);
				PuzzleEntries.Value.Add(new PuzzleEntryWrapper(newEntry, play));
			}
			foreach (string name in dummyData.PlayerDatabase.PlayerNames)
			{
				if (!gameData.PlayerDatabase.PlayerNames.Contains(name))
				{
					gameData.PlayerDatabase.CreateNewProfile(name);
				}
			}
		}
	}

	public class PuzzleEntryWrapper
	{
		public PuzzleEntryWrapper(IPuzzleLibraryEntry PuzzleLibraryEntry, Action playCallback)
		{
			this.PuzzleLibraryEntry = PuzzleLibraryEntry;
			this.Play = playCallback;
			this.PlayCmd = new RelayCommand(Play);
		}

		public Action Play { get; }

		public ICommand PlayCmd { get; }

		public IPuzzleLibraryEntry PuzzleLibraryEntry { get; private set; }

		public override string ToString()
		{
			var pzl = PuzzleLibraryEntry;
			return String.Format("{0} | {1}x{2}", pzl.Author, pzl.Puzzle.Size.Width, pzl.Puzzle.Size.Height);
		}
	}
}
