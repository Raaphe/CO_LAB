using PAT.ViewModels;

namespace PAT.Views
{
	using Models.Entities;

	public partial class Login : ContentPage
	{
		private readonly LoginViewModel _viewModel;

		public Login(LoginViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = _viewModel = viewModel;
		}

		private async void OnSubmitClicked(object sender, EventArgs e)
		{
			var userName = EntryUsername.Text.Trim();
			var pwd = EntryPwd.Text.Trim();

			if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pwd))
			{
				await DisplayAlert("Error", "Please enter both username and password.", "OK");
				return;
			}

			Tutee? tutee = await _viewModel.GetTuteeAsync(userName, pwd);
			Tutor? tutor = await _viewModel.GetTutorAsync(userName, pwd);
			Teacher? teacher = await _viewModel.GetTeacherAsync(userName, pwd);

			if (tutee != null)
			{
				await DisplayAlert("Success", $"Logged in Tutee {tutee?.FirstName}", "OK");
				if (App.ShellViewModel != null)
				{
					App.ShellViewModel.Student = tutee;
					App.ShellViewModel.IsLoggedIn = true;
					await Shell.Current.GoToAsync("//meetups");
				}

				return;
			}

			else if (tutor != null)
			{
				await DisplayAlert("Error", $"{tutor}", "OK");
				if (!(tutor.IsValidated))
				{
					await DisplayAlert("Error", "Please wait to be validated, try again after receiving your confirmation email!", "OK");
				}
				else
				{
					await DisplayAlert("Success", $"Logged in Tutor {tutor?.FirstName}", "OK");
					if (App.ShellViewModel != null)
					{
						App.ShellViewModel.Student = tutor;
						App.ShellViewModel.IsLoggedIn = true;
						await Shell.Current.GoToAsync("//meetups");
					}
				}
				return;
			}
			else if (teacher != null)
			{
				await DisplayAlert("Success", $"Logged in Teacher {teacher?.FirstName}", "OK");
				return;
			}

			await DisplayAlert("Error", "Invalid username or password.", "OK");

		}
	}
}