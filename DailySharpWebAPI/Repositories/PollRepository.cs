using DailySharpWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

/// <summary>
/// Crud
/// </summary>
public class PollRepository : IPollRepository
{

    public DailyContext _context;


    public PollRepository(DailyContext context)
    {
        _context = context;
    }

    public async Task<Poll> Create(Poll poll)
    {
     
        _context.Add(poll);
         await _context.SaveChangesAsync();

   

        return poll;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Poll"></typeparam>
    /// <param name="pollId"></param>
    /// <returns></returns>
    public async Task<Poll?> Read(long pollId)
    {

        return await _context.Polls.Where(p=>p.Id == pollId).Include(p=>p.Questions).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Poll>> ReadAll()
    {
        return await _context.Polls.ToListAsync();
    }

    public async Task<Poll> UpdatePut(Poll poll)
    {

        return new Poll();
    }

    public async Task<bool> Delete(long pollId)
    {

        return false;
    }

}