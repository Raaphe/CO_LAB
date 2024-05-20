// PAT Project - Sharp Coders

namespace PAT.Models.Repositories;

using Data;
using Entities;

public class TuteeRepository : Repository<Tutee>, ITuteeRepository
{
    private AppDbContext _context;

    public TuteeRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }
}