using PAT.Models.Entities;
using PAT.ViewModels;

namespace PAT.Views;

using Data;

public partial class Signup : ContentPage
{
    private readonly SignUpViewModel _viewModel;

    public Signup(AppDbContext dbContext)
    {
        InitializeComponent();
        _viewModel = new SignUpViewModel(dbContext);
        BindingContext = _viewModel;
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
            string.IsNullOrWhiteSpace(passwd))
        {
            await DisplayAlert("Validation Failed", "Please fill in all required fields.", "OK");
            return;
        }

        if (!IsPasswordStrong(passwd))
        {
            await DisplayAlert("Validation Failed", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.", "OK");
            return;
        }

        if (!(isTutee || isTutor || isTeacher))
        {
            await DisplayAlert("Validation Failed", "Please select at least one role.", "OK");
            return;
        }

        if ((isTutee && (isTutor || isTeacher)) ||
            (isTutor && (isTutee || isTeacher)) ||
            (isTeacher && (isTutee || isTutor)))
        {
            await DisplayAlert("Validation Failed", "Please select only one role.", "OK");
            return;
        }

        try
        {
            if (isTutee)
            {

	            var tutee = new Tutee
	            {
		            Email = email,
		            Availabilities = new List<Availability>(),
		            Meetings = new List<Meeting>(),
		            Messages = new List<Message>(),
		            IsDeleted = false,
		            LastName = lastName,
		            FirstName = firstName,
		            Password = passwd,
		            Program = _viewModel.SelectedProgram,
	            };
                await _viewModel.createNewTutee(tutee);

                await DisplayAlert("Success", "Tutee account created successfully!", "OK");
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
		            Availabilities = new List<Availability>(),
		            Meetings = new List<Meeting>(),
		            Messages = new List<Message>(),
		            IsDeleted = false,
		            LastName = lastName,
		            FirstName = firstName,
		            IsValidated = true,
		            Password = passwd,
		            Program = _viewModel.SelectedProgram,
	            };
                await _viewModel.createNewTutor(tutor);

                await DisplayAlert("Success", "Tutor account sent for validation!", "OK");
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
		            Messages = new List<Message>(),
		            IsDeleted = false,
		            LastName = lastName,
		            FirstName = firstName,
		            IsValidated = false,
		            Password = passwd
	            };
                await _viewModel.createNewTeacher(teacher);

                await DisplayAlert("Success", "Teacher account created successfully!", "OK");
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
            await DisplayAlert("Error", "An unexpected error occurred. Please try again later.", "OK");
        }
    }

    private bool IsPasswordStrong(string password)
    {
	    return true;
        /*var hasMinimumLength = password.Length >= 8;
        var hasUpperCase = password.Any(char.IsUpper);
        var hasLowerCase = password.Any(char.IsLower);
        var hasDigit = password.Any(char.IsDigit);
        var hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

        return hasMinimumLength && hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;*/
    }
}
