using Microsoft.Maui.Controls;
using System;

namespace PAT.Views
{
	using Data;
	using Models.Entities;

	public partial class DayTimePickerModal : ContentPage
	{
		private readonly AppDbContext _context;
		public DayOfWeek SelectedDay { get; private set; }
		public TimeSpan SelectedStartTime { get; private set; }
		public TimeSpan SelectedEndTime { get; private set; }

		public DayTimePickerModal(AppDbContext appDbContext)
		{
			InitializeComponent();
			InitializePickers();

			_context = appDbContext;
		}

		private void InitializePickers()
		{
			DayPicker.ItemsSource = Enum.GetValues(typeof(DayOfWeek));
			DayPicker.SelectedIndex = 0;
			StartTimePicker.Time = TimeSpan.FromHours(8);
			EndTimePicker.Time = TimeSpan.FromHours(17);
		}


		private async void OnConfirmClicked(object sender, EventArgs e)
		{
			if (DayPicker.SelectedItem is DayOfWeek selectedDay)
			{
				App.ShellViewModel?.Student?.Availabilities?.Add(new Availability
				{
					DayOfWeek = SelectedDay,
					StartTime = StartTimePicker.Time,
					EndTime = EndTimePicker.Time,
					Student = App.ShellViewModel.Student,
					IsDeleted = false
				});

				await _context.SaveChangesAsync();

				SelectedDay = SelectedDay;
				SelectedStartTime = StartTimePicker.Time;
				SelectedEndTime = EndTimePicker.Time;
				await Navigation.PopModalAsync();
			}
		}
	}
}