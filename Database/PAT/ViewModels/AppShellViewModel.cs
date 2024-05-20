// PAT Project - Sharp Coders

namespace PAT.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using Models.Entities;

    public partial class AppShellViewModel : ObservableObject
    {

        [ObservableProperty]
        private bool _isTutor;
        private bool _isLoggedIn;
        private Student? _student;



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
                if (_student != null)
                {
                    if (_student is Tutee tutee)
                    {
                        IsTutor = false;
                    }
                    else
                    {
                        IsTutor = true;
                    }
                }
                if (_student == value)
                    return;
                _student = value;
                OnPropertyChanged();
            }
        }
    }
}