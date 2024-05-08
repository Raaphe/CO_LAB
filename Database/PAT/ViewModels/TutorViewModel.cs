namespace PAT.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data;
using Models;
using Models.Entities;
using Task = System.Threading.Tasks.Task;

public sealed partial class TutorViewModel(AppDbContext context): ObservableObject, IDisposable
{
	[ObservableProperty]
	private Tutor tutor = new();

	[ObservableProperty]
	private string hasErrorsCodeBehind = string.Empty;

	[RelayCommand]
	private async Task CreateTutor(Tutor tutorParam)
	{
		context.Tutors.Add(tutorParam);
		await context.SaveChangesAsync();
	}

	public void Dispose() => context.Dispose();
}