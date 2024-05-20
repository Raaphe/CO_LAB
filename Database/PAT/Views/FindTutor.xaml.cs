// PAT Project - Sharp Coders

using PAT.Data;
using PAT.Models.Entities;
using PAT.ViewModels;

namespace PAT.Views
{
    public partial class FindTutor : ContentPage
    {
        private readonly FindTutorViewModel _viewModel;

        public FindTutor(AppDbContext appDbContext)
        {
            InitializeComponent();
            BindingContext = _viewModel = new FindTutorViewModel(appDbContext);
            LoadDataAsync();
        }

        private async void LoadDataAsync() => await _viewModel.LoadStudentsCoursesAsync();

        private void OnSubmitClicked(object sender, EventArgs e)
        {

        }

        private async void OnBackButtonClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//meetups");

        private void OnCourseSelectedChanged(object? sender, EventArgs e)
        {
            if (CoursePicker.SelectedItem is Course selectedCourse)
            {
                _viewModel.SelectedCourse = selectedCourse;
            }
        }
        private async void OnAddButtonClicked(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.BindingContext is Meeting meeting)
                {
                    if (App.ShellViewModel?.Student is Tutor)
                    {
                        await DisplayAlert("Cannot Process", $"Tutors cannot schedule meetings.", "Ok");
                    }
                    else
                    {
                        _viewModel.ProcessMeeting(meeting);
                        await Shell.Current.GoToAsync("//meetups");
                    }
                }
            }
        }
    }
}