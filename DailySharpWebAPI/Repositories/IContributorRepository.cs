using Microsoft.AspNetCore.Mvc;
using System;

public interface IContributorRepository
{
    public Task<Contributor> Create(Contributor Poll);
    public Task<Contributor?> Read(long contributorId);
    public Task<ActionResult<IEnumerable<Contributor>>> ReadAll();
    public Task<Contributor> UpdatePut(Contributor poll);
    public Task<bool> Delete(long contributorId);
}
