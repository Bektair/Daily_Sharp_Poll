
using DailySharpWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class PollPostRepository : IPollPostRepository
{
    public DailyContext _context;

    public PollPostRepository(DailyContext context)
    {
        _context= context;
    }

    public async Task<PollPost> Create(PollPost pollPost)
    {
        _context.PollPosts.Add(pollPost);
        await _context.SaveChangesAsync();

        return pollPost;
    }
    public async Task<PollPost?> Read(long pollPostId)
    {
        var pollPost = await _context.PollPosts.Where(p => p.Id == pollPostId).Include(p=>p.Reactions).FirstOrDefaultAsync();
        //pollPost.Reactions

        return pollPost;
    }
    public async Task<PollPost> UpdatePut(PollPost pollPost)
    {
        _context.Entry(pollPost).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

        }

        return pollPost;
    }
    public async Task<bool> Delete(long pollPostId)
    {
        var pollPost = await _context.Questions.FindAsync(pollPostId);

        _context.Questions.Remove(pollPost);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<PollPost>> ReadAll()
    {
        return await _context.PollPosts.Include(p => p.Reactions).ToListAsync();
    }
}
