namespace PAT.Data;

using Microsoft.EntityFrameworkCore;
using Models.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Tutor> Tutors => Set<Tutor>();
	public DbSet<Tutee> Tutees => Set<Tutee>();
	public DbSet<Teacher> Teachers => Set<Teacher>();
	public DbSet<Meeting> Meetings => Set<Meeting>();
	public DbSet<Course> Courses => Set<Course>();
	public DbSet<Availability> Availabilities => Set<Availability>();
	public DbSet<Program> Programs => Set<Program>();


}