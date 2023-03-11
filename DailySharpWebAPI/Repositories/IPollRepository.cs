
using System;

public interface IPollRepository
{
    public Task<Poll> Create(Poll Poll);
    public Task<Poll?> Read(long pollId);
    public Task<Poll> UpdatePut(Poll poll);
    public Task<bool> Delete(long pollId);
    public Task<IEnumerable<Poll>> ReadAll();

}
