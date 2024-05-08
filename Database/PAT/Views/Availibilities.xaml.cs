using System.ComponentModel;

namespace PAT.Views
{
	using System.Collections.ObjectModel;
	using System.Runtime.CompilerServices;
	using Data;
	using Models.Entities;
	using ViewModels;

	public partial class Availibilities : ContentPage, INotifyPropertyChanged
	{
		private readonly AppDbContext _context;
		public ObservableCollection<Availability>? AvailabilityList { get; set; }

		public Availibilities(AppDbContext appDbContext)
		{
			InitializeComponent();
			_context = appDbContext;
			AvailabilityList = new ObservableCollection<Availability>(GetAvailabilityList() ?? new List<Availability>());
			BindingContext = this;
		}

		private List<Availability>? GetAvailabilityList()
		{
			return _context.Availabilities
			               .Where(a => App.ShellViewModel != null && App.ShellViewModel.Student != null && a.Student != null && a.Student.Id == App.ShellViewModel.Student.Id && !a.IsDeleted)
			               .AsEnumerable() // Force client-side evaluation
			               .OrderBy(a => a.DayOfWeek)
			               .ToList();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			AvailabilityList?.Clear();
			var availabilities = GetAvailabilityList();
			if (availabilities != null)
			{
				foreach (var availability in availabilities)
				{
					AvailabilityList?.Add(availability);
				}
			}
		}


		public new event PropertyChangedEventHandler? PropertyChanged;

		protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		private async void OnAddAvailabilityClicked(object sender, EventArgs e)
		{
			var modalPage = new DayTimePickerModal(_context);
			await Navigation.PushModalAsync(modalPage);
		}
	}
}