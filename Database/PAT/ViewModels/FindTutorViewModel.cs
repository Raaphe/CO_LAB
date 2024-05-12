namespace PAT.ViewModels;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

public sealed partial class FindTutorViewModel: ObservableObject, IDisposable, IAsyncDisposable
{


	private readonly AppDbContext _dbContext;
	public new event PropertyChangedEventHandler? PropertyChanged;
	private ObservableCollection<Course>? _courses;
	private ObservableCollection<Meeting>? Meetings;
	private Course? _selectedCourse;

	public ObservableCollection<Course>? Courses
	{
		get => _courses;
		set
		{
			_courses = value;
			OnPropertyChanged();
		}
	}

	public Course? SelectedCourse
	{
		get => _selectedCourse;
		set
		{
			_selectedCourse = value;
			OnPropertyChanged();
			LoadMeetings();
		}
	}

	private void LoadMeetings()
	{
		// Clear existing meetings
		Meetings?.Clear();

		var tutors = _dbContext
		             .Tutors.Where(tutor => App.ShellViewModel != null &&
		                                    _selectedCourse != null &&
		                                    tutor.Program == _selectedCourse.Program)
		             .Include(student => student.Availabilities!)
		             .AsEnumerable()
		             .Where(tutor => AvailabilityStudentMatches(App.ShellViewModel!.Student, tutor));



		foreach (var t in tutors)
		{
			foreach (var a in t.Availabilities!)
			{
				foreach (var studentAvailability in App.ShellViewModel?.Student?.Availabilities!)
				{
					if (!AvailabilitiesCoincide(studentAvailability, a))
					{
						continue;
					}

					var meetingStart = a.StartTime > studentAvailability.StartTime ? a.StartTime : studentAvailability.StartTime;
					var meetingEnd = a.EndTime < studentAvailability.EndTime ? a.EndTime : studentAvailability.EndTime;

					var existingMeeting =  Meetings!.FirstOrDefault(m =>
						                                               m.DayOfWeek == a.DayOfWeek &&
						                                               m.StartTime == meetingStart &&
						                                               m.EndTime == meetingEnd &&
						                                               m.Tutee == App.ShellViewModel.Student &&
						                                               m.Tutor == t &&
						                                               !m.IsDeleted);

					if (existingMeeting != null)
					{
						continue;
					}

					var meeting = new Meeting
					{
						StartTime = meetingStart,
						EndTime = meetingEnd,
						DayOfWeek = a.DayOfWeek,
						Tutee = App.ShellViewModel.Student as Tutee,
						Tutor = t,
						IsDeleted = false
					};

					Meetings!.Add(meeting);
				}
			}
		}
	}

	public FindTutorViewModel(AppDbContext context)
	{
		_dbContext = context;
		Courses = new ObservableCollection<Course>();
		Meetings = new ObservableCollection<Meeting>();
	}

	public async Task LoadStudentsCoursesAsync()
	{
		if (App.ShellViewModel?.Student == null || App.ShellViewModel.Student.Program == null)
		{
			return;
		}

		var programName = App.ShellViewModel.Student.Program.ProgramName;

		var courseBuffer = await _dbContext.Courses
		                                   .Where(c => c.Program.ProgramName == programName)
		                                   .ToListAsync();

		Courses?.Clear();
		foreach (var course in courseBuffer)
		{
			Courses?.Add(course);
		}
	}

	public void Dispose()
	{
		_dbContext.Dispose();
	}

	public async ValueTask DisposeAsync()
	{
		await _dbContext.DisposeAsync();
	}

	private new void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private bool AvailabilityStudentMatches(Student? tutee, Student tutor)
	{
		return (from tuteeAvailability in tutee?.Availabilities! from tutorAvailability in tutor.Availabilities! where AvailabilitiesCoincide(tuteeAvailability, tutorAvailability) select tuteeAvailability).Any();
	}

	private bool AvailabilitiesCoincide(Availability a1, Availability a2)
	{
		return a1.DayOfWeek == a2.DayOfWeek &&
		       !(a1.EndTime <= a2.StartTime || a1.StartTime >= a2.EndTime);
	}

}