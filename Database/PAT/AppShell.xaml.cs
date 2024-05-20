// PAT Project - Sharp Coders
//
// This file is part of the PAT project. For more information, visit https://github.com/Raaphe/CO_LAB

using PAT.ViewModels;

namespace PAT
{
    public partial class AppShell
    {

        private readonly AppShellViewModel? _viewModel;
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
}
