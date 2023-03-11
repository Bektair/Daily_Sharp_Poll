
using DailySharpWebAPI.Models;
using System;

public interface IPollPostRepository
{
    public Task<PollPost> Create(PollPost pollPost);
    public Task<PollPost?> Read(long pollPostId);
    public Task<PollPost> UpdatePut(PollPost pollPost);
    public Task<bool> Delete(long pollPostId);
    public Task<IEnumerable<PollPost>> ReadAll();

}
