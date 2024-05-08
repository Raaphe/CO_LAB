namespace PAT;

using CommunityToolkit.Maui;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Repositories;
using ViewModels;
using Views;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("PatDb"); });

		builder.Services.AddSingleton<SignUpViewModel>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<AppShellViewModel>();
		builder.Services.AddSingleton<TutorViewModel>();
		builder.Services.AddSingleton<TeacherViewModel>();
		builder.Services.AddSingleton<MeetupsViewModel>();

		builder.Services.AddSingleton<Signup>();
		builder.Services.AddSingleton<Login>();
		builder.Services.AddSingleton<ChatPage>();
		builder.Services.AddSingleton<Availibilities>();
		builder.Services.AddSingleton<DayTimePickerModal>();
		builder.Services.AddSingleton<MeetupsPage>();



		return builder.Build();
	}
}