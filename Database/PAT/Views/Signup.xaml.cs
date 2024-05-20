// PAT Project - Sharp Coders

using PAT.Data;
using PAT.Models.Entities;
using PAT.ViewModels;

namespace PAT.Views
{
    public partial class Signup : ContentPage, IDisposable
    {
        private readonly SignUpViewModel viewModel;
        private bool disposed = false;

        public Signup(AppDbContext dbContext)
        {
            InitializeComponent();
            viewModel = new SignUpViewModel(dbContext);
            BindingContext = viewModel;
        }

        public async void OnSignupClicked(object sender, EventArgs e)
        {
            var firstName = FName.Text;
            var lastName = LName.Text;
            var email = Email.Text;
            var passwd = Password.Text;

            var isTutee = TuteeRadioButton.IsChecked;
            var isTutor = TutorRadioButton.IsChecked;
            var isTeacher = TeacherRadioButton.IsChecked;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(passwd) ||
                viewModel.SelectedProgram == null)
            {
                await DisplayAlert("Validation Failed", "Please fill in all required fields.", "OK");
                return;
            }

            if (!IsPasswordStrong(passwd))
            {
                await DisplayAlert("Validation Failed", "\nLe mot de passe doit faire au minimum 8 caractères et contenir au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial.", "OK");
                return;
            }

            if (!(isTutee || isTutor || isTeacher))
            {
                await DisplayAlert("Validation Failed", "Veuillez chossir au moins un rôle.", "OK");
                return;
            }

            if ((isTutee && (isTutor || isTeacher)) ||
                (isTutor && (isTutee || isTeacher)) ||
                (isTeacher && (isTutee || isTutor)))
            {
                await DisplayAlert("Validation Failed", "Veuillez choissir un seul rôle.", "OK");
                return;
            }

            try
            {
                if (isTutee)
                {
                    var tutee = new Tutee
                    {
                        Email = email,
                        Availabilities = [],
                        Meetings = [],
                        Messages = [],
                        IsDeleted = false,
                        LastName = lastName,
                        FirstName = firstName,
                        Password = passwd,
                        Program = viewModel.SelectedProgram,
                    };
                    _ = await viewModel.createNewTutee(tutee);

                    await DisplayAlert("Succès", "Compte tutoré créé avec succès!", "OK");
                    if (App.ShellViewModel == null)
                    {
                        return;
                    }

                    App.ShellViewModel.Student = tutee;
                    App.ShellViewModel.IsLoggedIn = true;
                    await Shell.Current.GoToAsync("//meetups");
                }
                else if (isTutor)
                {
                    var tutor = new Tutor
                    {
                        Email = email,
                        Availabilities = [],
                        Meetings = [],
                        Messages = [],
                        IsDeleted = false,
                        LastName = lastName,
                        FirstName = firstName,
                        IsValidated = true,
                        Password = passwd,
                        Program = viewModel.SelectedProgram,
                    };
                    await viewModel.createNewTutor(tutor);

                    await DisplayAlert("Succès", "Compter tuteur créé avec succès!", "OK");
                    if (App.ShellViewModel == null)
                    {
                        return;
                    }

                    App.ShellViewModel.Student = tutor;
                    App.ShellViewModel.IsLoggedIn = true;
                    await Shell.Current.GoToAsync("//meetups");
                }
                else if (isTeacher)
                {
                    var teacher = new Teacher()
                    {
                        Email = email,
                        Messages = [],
                        IsDeleted = false,
                        LastName = lastName,
                        FirstName = firstName,
                        IsValidated = false,
                        Password = passwd
                    };
                    await viewModel.createNewTeacher(teacher);

                    await DisplayAlert("Succès", "Compte enseignant créé avec succès!", "OK");
                    if (App.ShellViewModel == null)
                    {
                        return;
                    }

                    // TODO: NEED TO MAKE MAINPAGE FOR TEACHER
                    App.ShellViewModel.IsLoggedIn = true;
                    await Shell.Current.GoToAsync("//meetups");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                await DisplayAlert("Error", "Une erreur inattendue s'est produite. Veuillez réessayer plus tard.", "OK");
            }
        }

        private bool IsPasswordStrong(string password)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var hasMinimumLength = password.Length >= 8;
            var hasUpperCase = password.Any(char.IsUpper);
            var hasLowerCase = password.Any(char.IsLower);
            var hasDigit = password.Any(char.IsDigit);
            var hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasMinimumLength && hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                viewModel?.Dispose();
            }

            disposed = true;
        }

        ~Signup()
        {
            Dispose(false);
        }
    }
}
