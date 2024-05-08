using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Views;

using ViewModels;

public partial class MeetupsPage : ContentPage
{
	private readonly MeetupsViewModel _meetupsViewModel;

	public MeetupsPage(MeetupsViewModel viewModel)
	{
		InitializeComponent();
		_meetupsViewModel = viewModel;
		BindingContext = viewModel;
	}

	public void NavigateToChat()
	{

	}

}