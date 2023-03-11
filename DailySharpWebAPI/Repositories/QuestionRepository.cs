
using DailySharpWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class QuestionRepository : IQuestionRepository
{
    public DailyContext _context;

    public QuestionRepository(DailyContext context)
    {
        _context = context;
    }

    public async Task<Question> Create(Question question)
    {

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return question;
    }
    public async Task<Question?> Read(long questionId)
    {
        var question = await _context.Questions.FindAsync(questionId);

        return question;
    }
    public async Task<Question> UpdatePut(Question question)
    {
        _context.Entry(question).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

        }

        return question;
    }
    public async Task<bool> Delete(long questionId)
    {
        var question = await _context.Questions.FindAsync(questionId);

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<IEnumerable<Question>> ReadAll()
    {
        return await _context.Questions.ToListAsync();
    }

    private bool QuestionExists(int id)
    {
        return _context.Questions.Any(e => e.Id == id);
    }

}
