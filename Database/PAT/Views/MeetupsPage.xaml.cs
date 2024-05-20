// PAT Project - Sharp Coders
//
// This file is part of the PAT project. For more information, visit https://github.com/Raaphe/CO_LAB

using PAT.Data;
using PAT.Models.Entities;
using PAT.ViewModels;

namespace PAT.Views
{
    public partial class MeetupsPage : ContentPage
    {
        private readonly MeetupsViewModel _meetupsViewModel;

        public MeetupsPage(AppDbContext appDbContext)
        {
            InitializeComponent();
            BindingContext = _meetupsViewModel = new MeetupsViewModel(appDbContext);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _meetupsViewModel.LoadMeetings();
        }

        private void NavigateToChats(object sender, EventArgs e)
        {
            Console.WriteLine("");
            Shell.Current.GoToAsync("//chat");
        }


        private void RemoveMeetups(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.BindingContext is Meeting meeting)
            {
                _meetupsViewModel.DeleteMeetingAsync(meeting);
                _meetupsViewModel.LoadMeetings();
            }
        }
    }
}