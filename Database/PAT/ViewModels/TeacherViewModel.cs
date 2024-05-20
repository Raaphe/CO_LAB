// PAT Project - Sharp Coders

namespace PAT.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data;
using Models.Entities;

public sealed partial class TeacherViewModel(AppDbContext context) : ObservableObject, IDisposable
{
    [ObservableProperty]
    private Teacher teacher = new();

    [ObservableProperty]
    private string hasErrorsCodeBehind = string.Empty;

    [RelayCommand]
    private async Task CreateTeacher(Teacher teacherParam)
    {
        context.Teachers.Add(teacherParam);
        await context.SaveChangesAsync();
    }

    public void Dispose() => context.Dispose();
}