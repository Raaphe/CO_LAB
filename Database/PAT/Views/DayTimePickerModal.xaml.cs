// PAT Project - Sharp Coders

using PAT.Data;
using PAT.Models.Entities;

namespace PAT.Views
{
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
            if (DayPicker.SelectedItem is not DayOfWeek)
            {
                return;
            }

            App.ShellViewModel?.Student?.Availabilities?.Add(new Availability
            {
                DayOfWeek = SelectedDay,
                StartTime = StartTimePicker.Time,
                EndTime = EndTimePicker.Time,
                Student = App.ShellViewModel.Student,
                IsDeleted = false
            });

            _ = await _context.SaveChangesAsync();

            SelectedStartTime = StartTimePicker.Time;
            SelectedEndTime = EndTimePicker.Time;
            _ = await Navigation.PopModalAsync();
        }

        private async void OnBackButtonClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//availabilities");
    }
}