// PAT Project - Sharp Coders

namespace PAT.Models.Repositories;

using Data;
using Entities;

public class TutorRepository : Repository<Tutor>, ITutorRepository
{
    private readonly AppDbContext _dbContext;

    public TutorRepository(AppDbContext context)
        : base(context)
    {
        this._dbContext = context;
    }
}