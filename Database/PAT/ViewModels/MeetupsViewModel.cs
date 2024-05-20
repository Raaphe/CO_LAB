// PAT Project - Sharp Coders

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PAT.Data;
using PAT.Models.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PAT.ViewModels
{
    public partial class MeetupsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Meeting>? meetings;

        public ICommand DeleteMeetingCommand { get; }
        private readonly AppDbContext context;

        public MeetupsViewModel(AppDbContext context)
        {
            DeleteMeetingCommand = new Command<Meeting>(Execute);
            this.context = context;
        }

        public void LoadMeetings()
        {
            if (App.ShellViewModel?.Student == null)
            {
                return;
            }

            if (App.ShellViewModel.Student is Tutor tutor)
            {
                Meetings = new ObservableCollection<Meeting>(
                    context.Meetings.Where(m => m.Tutor != null && !m.IsDeleted && m.Tutor.Id == tutor.Id)
                );
                return;
            }

            if (App.ShellViewModel.Student is Tutee tutee)
            {
                Meetings = new ObservableCollection<Meeting>(
                    context.Meetings.Where(m => m.Tutee != null && m.Tutor != null && !m.IsDeleted && m.Tutee.Id == tutee.Id)
                );
            }
        }

        private async void Execute(Meeting meeting)
        {
            Meeting? fullMeetingEntity = await context.Meetings.SingleOrDefaultAsync(m => m.Id == meeting.Id);

            if (fullMeetingEntity == null)
            {
                return;
            }

            fullMeetingEntity.IsDeleted = true;
            _ = context.Meetings.Update(fullMeetingEntity);
        }

        internal async void DeleteMeetingAsync(Meeting meeting)
        {
            if (meeting == null)
            {
                return;
            }

            context.Meetings.Remove(meeting);
            await context.SaveChangesAsync();
        }
    }
}