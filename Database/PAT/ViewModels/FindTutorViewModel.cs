namespace PAT.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

public sealed partial class FindTutorViewModel (AppDbContext _dbContext) : ObservableObject, IDisposable, IAsyncDisposable
{
	public void Dispose()
	{
		_dbContext.Dispose();
	}

	public async ValueTask DisposeAsync()
	{
		await _dbContext.DisposeAsync();
	}

	public async Task<List<Tutor>> GetAvailableTutorsAsync(string program)
	{
		return await _dbContext.Tutors
		                       .Where(tutor => tutor.Program != null && tutor.Program.ProgramName == program)
		                       .ToListAsync();
	}

}