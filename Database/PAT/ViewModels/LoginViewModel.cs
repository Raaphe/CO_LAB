using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace PAT.ViewModels
{
	using Data;
	using Models.Entities;

	public sealed partial class LoginViewModel (AppDbContext _dbContext) : ObservableObject, IDisposable, IAsyncDisposable
	{
		public void Dispose()
		{
			_dbContext.Dispose();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public async Task<Tutee?> GetTuteeAsync(string username, string pwd)
		{
			var tutee = await _dbContext.Tutees.SingleOrDefaultAsync(t => t.Email == username);
			return tutee ;
		}


		public async Task<Tutor?> GetTutorAsync(string username, string pwd)
		{
			return await _dbContext.Tutors.SingleOrDefaultAsync(tutee1 => tutee1.Email == username) ?? new Tutor();
		}

		public async Task<Teacher?> GetTeacherAsync(string username, string pwd)
		{
			return await _dbContext.Teachers.SingleOrDefaultAsync(tutee1 => tutee1.Email == username) ?? new Teacher();
		}
	}
}