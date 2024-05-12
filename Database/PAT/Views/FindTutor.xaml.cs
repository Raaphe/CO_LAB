namespace PAT.Views
{
	using Data;
	using Models.Entities;
	using ViewModels;

	public partial class FindTutor : ContentPage
	{
		private readonly FindTutorViewModel _viewModel;

		public FindTutor(AppDbContext appDbContext)
		{
			InitializeComponent();
			BindingContext = _viewModel = new FindTutorViewModel(appDbContext);
			LoadDataAsync();
		}

		private async void LoadDataAsync()
		{
			await _viewModel.LoadStudentsCoursesAsync();
		}

		private void OnSubmitClicked(object sender, EventArgs e)
		{

		}

		private async void OnBackButtonClicked(object? sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//meetups");
		}

		private void OnCourseSelectedChanged(object? sender, EventArgs e)
		{
			if (CoursePicker.SelectedItem is Course selectedCourse)
			{
				_viewModel.SelectedCourse = selectedCourse;
			}
		}

		private void OnAddButtonClicked(object? sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}