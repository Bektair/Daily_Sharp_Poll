using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailySharpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorsController : ControllerBase
    {
        private readonly DailyContext _context;
        private readonly IContributorRepository _contRepo;
        private readonly IMapper _mapper;


        public ContributorsController(DailyContext context, IContributorRepository contRepo, IMapper mapper)
        {
            _context = context;
            _contRepo = contRepo;
            _mapper = mapper;
        }

        // GET: api/Contributors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContributorReadDTO>>> GetContributors()
        {
            var allContrib = await _contRepo.ReadAll();

            var allContribDTO = allContrib.Value.Select(c =>_mapper.Map<ContributorReadDTO>(c)).ToArray();

            return allContribDTO;
        }

        // GET: api/Contributors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContributorReadDTO>> GetContributor(long id)
        {
            var contributor = await _contRepo.Read(id);

            if (contributor == null)
            {
                return NotFound();
            }

            var contributorDTO = _mapper.Map<ContributorReadDTO>(contributor);

            return contributorDTO;
        }

        // PUT: api/Contributors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContributor(long id, Contributor contributor)
        {
            if (id != contributor.Id)
            {
                return BadRequest();
            }

            _context.Entry(contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contributors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContributorReadDTO>> PostContributor(ContributorCreateDTO contributorDTO)
        {

            var contributor = _mapper.Map<Contributor>(contributorDTO);

            await _contRepo.Create(contributor);

            return CreatedAtAction("GetContributor", new { id = contributor.DiscordId }, contributor);
        }

        // DELETE: api/Contributors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContributor(long id)
        {
            bool deleted = await _contRepo.Delete(id);
            if (!deleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        private bool ContributorExists(long id)
        {
            return _context.Contributors.Any(e => e.Id == id);
        }
    }
}
