
using System;

public interface IQuestionRepository
{
    public Task<Question> Create(Question Question);
    public Task<Question?> Read(long questionId);
    public Task<Question> UpdatePut(Question Question);
    public Task<bool> Delete(long questionId);
    public Task<IEnumerable<Question>> ReadAll();

}
