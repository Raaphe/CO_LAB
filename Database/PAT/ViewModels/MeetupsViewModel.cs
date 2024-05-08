namespace PAT.ViewModels;

using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

public class MeetupsViewModel : BindableObject
{
	public ObservableCollection<Meeting> Meetings { get; set; }

	public ICommand DeleteMeetingCommand { get; }
	private readonly AppDbContext _context;

	public MeetupsViewModel(AppDbContext context)
	{
		Meetings = new ObservableCollection<Meeting>();

		DeleteMeetingCommand = new Command<Meeting>(Execute);
		_context = context;
	}

	public MeetupsViewModel()
	{
		throw new NotImplementedException();
	}

	private async void Execute(Meeting meeting)
	{
		var fullMeetingEntity = await _context.Meetings.SingleOrDefaultAsync(m => m.Id == meeting.Id);

		if (fullMeetingEntity != null)
		{
			fullMeetingEntity.IsDeleted = true;
			_context.Meetings.Update(fullMeetingEntity);
			return;
		}
	}




}