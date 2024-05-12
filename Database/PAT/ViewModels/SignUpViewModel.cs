namespace PAT.ViewModels;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using Models.Entities;

public sealed partial class SignUpViewModel : ObservableObject, IDisposable, IAsyncDisposable, INotifyPropertyChanged
{
	private ObservableCollection<Program>? _programs;
	private Program? _selectedProgram;
	private readonly AppDbContext _context;


	public new event PropertyChangedEventHandler? PropertyChanged;

	public ObservableCollection<Program>? Programs
	{
		get => _programs;
		set
		{
			_programs = value;
			OnPropertyChanged();
		}
	}

	public Program? SelectedProgram
	{
		get => _selectedProgram;
		set
		{
			_selectedProgram = value;
			OnPropertyChanged();
		}
	}

	public SignUpViewModel(AppDbContext dbContext)
	{
		// Initialize the Programs collection and add sample data
		_context = dbContext;
		Programs = new ObservableCollection<Program>();
		LoadPrograms();
	}

	private void LoadPrograms()
	{
		foreach (var p in _context.Programs)
		{
			Programs?.Add(p);

		}
	}

	private new void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public void Dispose()
	{
		_context.Dispose();
	}

	public async ValueTask DisposeAsync()
	{
		await _context.DisposeAsync();
	}

	public async Task<bool> createNewTutee(Tutee tutee)
	{
		if (_context.Tutees.Any(t => t.Email == tutee.Email))
		{
			return false;
		}

		_context.Tutees.Add(tutee);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task createNewTutor(Tutor tutor)
	{
		if (_context.Tutors.Any(t => t.Email == tutor.Email))
		{
			return;
		}

		_context.Tutors.Add(tutor);
		await _context.SaveChangesAsync();
	}

	public async Task createNewTeacher(Teacher teacher)
	{
		if (_context.Teachers.Any(t => t.Email == teacher.Email))
		{
			return;
		}

		_context.Teachers.Add(teacher);
		await _context.SaveChangesAsync();
	}
}