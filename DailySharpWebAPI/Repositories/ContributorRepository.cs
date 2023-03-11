using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

/// <summary>
/// Crud
/// </summary>
public class ContributorRepository : IContributorRepository
{

    public DailyContext _context;


    public ContributorRepository(DailyContext context)
    {
        _context = context;
    }

    public async Task<Contributor> Create(Contributor contributor)
    {
        _context.Contributors.Add(contributor);
        await _context.SaveChangesAsync();

        return contributor;
    }


    public async Task<Contributor?> Read(long contributorId)
    {
        var contributor = await _context.Contributors.FindAsync(contributorId);

        return contributor;
    }
    public async Task<ActionResult<IEnumerable<Contributor>>> ReadAll()
    {
        return await _context.Contributors.ToListAsync();

    }

    public async Task<Contributor> UpdatePut(Contributor poll)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(long contributorId)
    {
        var contributor = await _context.Contributors.FindAsync(contributorId);
        if (contributor == null)
        {
            return false;
        }

        _context.Contributors.Remove(contributor);
        return await _context.SaveChangesAsync() > 0;
    }
}