// PAT Project - Sharp Coders

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PAT.Data;
using PAT.Models.Entities;
using System.Collections.ObjectModel;

namespace PAT.ViewModels
{
    public sealed partial class FindTutorViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        [ObservableProperty]
        private ObservableCollection<Course>? _courses;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Meetings))]
        private Course? _selectedCourse;

        public ICollection<Meeting> Meetings => LoadMeetings();




        public FindTutorViewModel(AppDbContext context)
        {
            _dbContext = context;
            Courses = [];
        }

        private ICollection<Meeting> LoadMeetings()
        {
            // Clear existing meetings
            var resultList = new Collection<Meeting>();

            IEnumerable<Tutor> tutors = _dbContext
                         .Tutors.Where(tutor => App.ShellViewModel != null &&
                                                SelectedCourse != null &&
                                                tutor.Program == SelectedCourse.Program)
                         .Include(student => student.Availabilities!)
                         .AsEnumerable()
                         .Where(tutor => AvailabilityStudentMatches(App.ShellViewModel!.Student, tutor));



            foreach (Tutor t in tutors)
            {
                foreach (Availability a in t.Availabilities!)
                {
                    foreach (Availability studentAvailability in App.ShellViewModel?.Student?.Availabilities!)
                    {
                        if (!AvailabilitiesCoincide(studentAvailability, a))
                        {
                            continue;
                        }

                        TimeSpan meetingStart = a.StartTime > studentAvailability.StartTime ? a.StartTime : studentAvailability.StartTime;
                        TimeSpan meetingEnd = a.EndTime < studentAvailability.EndTime ? a.EndTime : studentAvailability.EndTime;

                        Meeting? existingMeeting = _dbContext.Meetings!.FirstOrDefault(m =>
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
                            Course = SelectedCourse,
                            IsDeleted = false
                        };

                        resultList!.Add(meeting);
                    }
                }
            }

            return resultList;
        }

        public async Task LoadStudentsCoursesAsync()
        {
            if (App.ShellViewModel?.Student == null || App.ShellViewModel.Student.Program == null)
            {
                return;
            }

            var programName = App.ShellViewModel.Student.Program.ProgramName;

            List<Course> courseBuffer = await _dbContext.Courses
                                               .Where(c => c.Program.ProgramName == programName)
                                               .ToListAsync();

            Courses?.Clear();
            foreach (Course course in courseBuffer)
            {
                Courses?.Add(course);
            }
        }

        private bool AvailabilityStudentMatches(Student? tutee, Student tutor) => (from tuteeAvailability in tutee?.Availabilities! from tutorAvailability in tutor.Availabilities! where AvailabilitiesCoincide(tuteeAvailability, tutorAvailability) select tuteeAvailability).Any();

        private bool AvailabilitiesCoincide(Availability a1, Availability a2) => a1.DayOfWeek == a2.DayOfWeek &&
                   !(a1.EndTime <= a2.StartTime || a1.StartTime >= a2.EndTime);

        public async void ProcessMeeting(Meeting meeting)
        {
            _dbContext.Meetings.Add(meeting);
            await _dbContext.SaveChangesAsync();
            LoadMeetings();
        }
    }
}