namespace PAT;

using ViewModels;

public partial class AppShell : Shell
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
}