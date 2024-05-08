using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PAT.Views
{
	using Data;
	using Models.Entities;
	using ViewModels;

	public partial class FindTutor : ContentPage
	{
		private readonly FindTutorViewModel _viewModel;
		private readonly AppDbContext _context;
		public ObservableCollection<Tutor>? Tutors { get; set; }

		public FindTutor(FindTutorViewModel findTutorViewModel, AppDbContext appDbContext)
		{
			InitializeComponent();
			_context = appDbContext;
			BindingContext = _viewModel = findTutorViewModel;

			var loadTutorsAsync = LoadTutorsAsync();
		}

		private async Task LoadTutorsAsync()
		{
			var programName = App.ShellViewModel?.Student?.Program?.ProgramName;
			if (!string.IsNullOrEmpty(programName))
			{
				var tutors = await _viewModel.GetAvailableTutorsAsync(programName);
				Tutors = new ObservableCollection<Tutor>(tutors);
			}
			else
			{
				Tutors = new ObservableCollection<Tutor>();
			}
		}

		private async void OnSubmitClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Error", $"{Tutors}", "OK");
		}
	}
}