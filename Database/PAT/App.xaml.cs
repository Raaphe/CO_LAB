namespace PAT;

using System.Text;
using Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Entities;
using ViewModels;

public partial class App : Application
{
	public static AppShellViewModel? ShellViewModel { get; private set; }
	private readonly AppDbContext _context;
	private static Random random = new();

	public App(AppDbContext context)
	{
		InitializeComponent();
		ShellViewModel = new AppShellViewModel();
		MainPage = new AppShell(ShellViewModel);
		_context = context;
	}

	protected override async void OnStart()
	{
		base.OnStart();
		await LoadData();
	}

	private async Task LoadData()
	{
		var programs = new List<string>() {"Informatique", "Design Interieur", "Histoire et Civilisation", "Science Naturelle", "Design de Mode", "Education Spécialisée", "Musique", "Graphisme"};

		var courses = new List<Course>
		{
			new Course { CourseCode = "MQ-109-120", CourseCredits = 1.33, CourseName = "Introduction à la programation", IsDeleted = false },
			new Course { CourseCode = "MV-123-111", CourseCredits = 2.33, CourseName = "AutoCad", IsDeleted = false },
			new Course { CourseCode = "PH-201-101", CourseCredits = 3, CourseName = "Philosophie", IsDeleted = false },
			new Course { CourseCode = "GE-312-245", CourseCredits = 2.66, CourseName = "Géometrie Vectorielle", IsDeleted = false },
			new Course { CourseCode = "CF-401-105", CourseCredits = 1, CourseName = "Confection", IsDeleted = false },
			new Course { CourseCode = "ED-502-201", CourseCredits = 2, CourseName = "L'activité en éducation spécialisée", IsDeleted = false },
			new Course { CourseCode = "CH-601-333", CourseCredits = 2.33, CourseName = "Chorale 1", IsDeleted = false },
			new Course { CourseCode = "TY-712-100", CourseCredits = 1, CourseName = "Typographie", IsDeleted = false }
		};

		var i = 0;
		foreach (var programName in programs)
		{
			var program = new PAT.Models.Entities.Program
			{
				Courses = new List<Course>{ courses[i] },
				IsDeleted = false,
				ProgramCode = GenerateRandomString(),
				ProgramName = programName
			};

			_context.Programs.Add(program);
			i++;
		}

		_context.Teachers.Add(new Teacher
		{
			FirstName = "teacher",
			LastName = "teacher",
			Email = "teacher",
			IsDeleted = false,
			IsValidated = true,
			Password = "teacher"
		});

		await _context.SaveChangesAsync();
	}


	private string GenerateRandomString()
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		StringBuilder builder = new StringBuilder();

		for (int i = 0; i < 6; i++)
		{
			if (i == 2)
				builder.Append('-');
			else
				builder.Append(chars[random.Next(chars.Length)]);
		}
		return builder.ToString();
	}
}