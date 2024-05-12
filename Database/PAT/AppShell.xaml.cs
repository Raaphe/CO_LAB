namespace PAT;

using ViewModels;

public partial class AppShell
{

	private AppShellViewModel? _viewModel;
	public AppShell(AppShellViewModel? viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;

	}

	public AppShell()
	{
		InitializeComponent();
		BindingContext = new AppShellViewModel();
	}

	private async void OnLogoutClicked(object? sender, EventArgs eventArgs)
	{
		if (App.ShellViewModel != null)
		{
			App.ShellViewModel.Student = null;
			App.ShellViewModel.IsLoggedIn = false;
		}

		await Current.GoToAsync("//login");
	}

}