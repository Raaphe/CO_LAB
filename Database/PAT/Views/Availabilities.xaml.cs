// PAT Project - Sharp Coders

using System.ComponentModel;
using PAT.Data;
using PAT.Models.Entities;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PAT.Views
{
    public partial class Availabilities : INotifyPropertyChanged
    {
        private readonly AppDbContext _context;
        public ObservableCollection<Availability>? AvailabilityList { get; set; }

        public Availabilities(AppDbContext appDbContext)
        {
            InitializeComponent();
            _context = appDbContext;
            AvailabilityList = new ObservableCollection<Availability>(GetAvailabilityList() ?? []);
            BindingContext = this;
        }

        private List<Availability>? GetAvailabilityList() => [.. _context.Availabilities
                           .Where(a => App.ShellViewModel != null && App.ShellViewModel.Student != null && a.Student != null && a.Student.Id == App.ShellViewModel.Student.Id && !a.IsDeleted)
                           .AsEnumerable()
                           .OrderBy(a => a.DayOfWeek)];

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AvailabilityList?.Clear();
            List<Availability>? availabilities = GetAvailabilityList();
            if (availabilities == null)
            {
                return;
            }

            foreach (Availability availability in availabilities)
            {
                AvailabilityList?.Add(availability);
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

        private async void OnBackButtonClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//meetups");

        private void OnDeleteAvailabilityClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.BindingContext is Availability availability)
            {
                AvailabilityList?.Remove(availability);
                _context.Availabilities.Remove(availability);
                _context.SaveChanges();
            }
        }
    }
}