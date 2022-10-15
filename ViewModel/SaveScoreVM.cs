using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
	public class SaveScoreVM
	{
		public TimeSpan BestTime { get; }
		public string BestTimePlayerName { get; }
		public Cell<TimeSpan?> SelectedPlayerTime { get; }
		public ObservableCollection<string> PlayerNames { get; }
		public Cell<string> PlayerNamesSelection { get; } = Cell.Create<string>(null);
		public TimeSpan Time { get; }
		public string AddPlayerName { get; set; }
		public ICommand AddPlayerCmd { get; }
		public ICommand SaveTimeCmd { get; }

		private Action doneSavingCallback;
		private IGameData gameData;
		private IPuzzleLibraryEntry puzzleLibraryEntry;

		public SaveScoreVM(Action<object> setViewModel, ref IGameData gameData, ref IPuzzleLibraryEntry puzzleLibraryEntry, TimeSpan time, Action doneSavingCallback)
		{
			this.gameData = gameData;
			this.puzzleLibraryEntry = puzzleLibraryEntry;
			this.Time = time;
			this.doneSavingCallback = doneSavingCallback;
			this.PlayerNames = new ObservableCollection<string>(gameData.PlayerDatabase.PlayerNames);
			if (PlayerNames.Count != 0)
			{
				PlayerNamesSelection.Value = PlayerNames.First();
			}

			this.SelectedPlayerTime = Cell.Derived(PlayerNamesSelection, name =>
			{
				return this.gameData.PlayerDatabase[PlayerNamesSelection.Value][this.puzzleLibraryEntry].BestTime;
			});

			TimeSpan bestTime = TimeSpan.MaxValue;
			string bestTimePlayerName = "/";
			foreach (string name in PlayerNames)
			{
				var playerTime = gameData.PlayerDatabase[name][this.puzzleLibraryEntry].BestTime;
				if (playerTime != null && playerTime < bestTime)
				{
					bestTime = playerTime.Value;
					bestTimePlayerName = name;
				}
			}
			BestTime = bestTime;
			BestTimePlayerName = bestTimePlayerName;

			this.AddPlayerCmd = new RelayCommand(AddPlayer);
			this.SaveTimeCmd = new RelayCommand(SaveTime);
		}

		public void AddPlayer()
		{
			var name = AddPlayerName;
			gameData.PlayerDatabase.CreateNewProfile(name);
			PlayerNames.Add(name);
			PlayerNamesSelection.Value = name;
		}

		public void SaveTime()
		{
			gameData.PlayerDatabase[PlayerNamesSelection.Value][puzzleLibraryEntry].BestTime = Time;
			doneSavingCallback();
		}
	}
}
