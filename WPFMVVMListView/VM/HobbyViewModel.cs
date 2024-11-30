using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WPFMVVMListView.Command;
using WPFMVVMListView.Models;

namespace WPFMVVMListView.VM
{

    public class HobbyViewModel : ViewModelBase
    {
		private ObservableCollection<HobbyItemViewModel> hobbies = new();
        private HobbyItemViewModel selectedHobby;
        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<HobbyItemViewModel> Hobbies
		{
			get { return hobbies; }
            set { hobbies = value;
                RaisePropertyChanged();
            }
		}

        public HobbyItemViewModel SelectedHobby
        {
            get { return selectedHobby; }
            set { selectedHobby = value;
                RaisePropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public HobbyViewModel()
        {
            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Knitting", Description = "Very exciting stuff" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Baking", Description = "Not as exciting as knitting, but not bad" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Painting", Description = "I love watching paint dry :)" }));

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

        public async Task LoadAsync()
        {
            if (Hobbies.Any())
            {
                return;
            }
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new() { Name = string.Empty, Description = string.Empty };
            var hobbyVM = new HobbyItemViewModel(hobby);
            Hobbies.Add(hobbyVM);
            SelectedHobby = hobbyVM;
        }

        private void DeleteHobby(object? parameter)
        {
            if (selectedHobby != null)
            {
                Hobbies.Remove(selectedHobby);
                SelectedHobby = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedHobby != null;

        public async void HobbiesView_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadAsync();
        }
    }
}
