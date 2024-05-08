using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PAT.ViewModels
{
	using Models.Entities;

	public class AppShellViewModel : INotifyPropertyChanged
	{
		private bool _isLoggedIn;
		private Student? _student;

		public event PropertyChangedEventHandler? PropertyChanged;

		public bool IsLoggedIn
		{
			get => _isLoggedIn;
			set
			{
				if (_isLoggedIn == value)
					return;
				_isLoggedIn = value;
				OnPropertyChanged();
			}
		}

		public Student? Student
		{
			get => _student;
			set
			{
				if (_student == value)
					return;
				_student = value;
				OnPropertyChanged();
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}