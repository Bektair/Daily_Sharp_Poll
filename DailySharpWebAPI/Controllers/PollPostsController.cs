using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DailySharpWebAPI.DTOs;
using DailySharpWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DailySharpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollPostsController : ControllerBase
    {
        private readonly DailyContext _context;
        private readonly IMapper _mapper;
        private readonly IPollRepository _pollRepository;
        private readonly IPollPostRepository _ppRepository;
        private readonly IQuestionRepository _questionRepository;

        public PollPostsController(DailyContext context, IMapper mapper, IPollRepository pollRepository, IPollPostRepository pqRepository, IQuestionRepository questionRepository)
        {
            _context = context;
            _mapper = mapper;
            _pollRepository = pollRepository;
            _ppRepository = pqRepository;
            _questionRepository = questionRepository;
        }

        // GET: api/Polls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollPostReadDTO>>> GetPolls()
        {

            IEnumerable<PollPost> polls = await _ppRepository.ReadAll();

            PollPostReadDTO[] pollsDTO = _mapper.Map<IEnumerable<PollPostReadDTO>>(polls).ToArray();
            return pollsDTO;
        }

        // GET: api/Polls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollPostReadDTO>> GetPoll(long id)
        {
            PollPost? poll = await _ppRepository.Read(id);

            if (poll == null)
            {
                return NotFound();
            }

            return _mapper.Map<PollPostReadDTO>(poll);
        }

        // PUT: api/Polls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(long id, PollPost pollPost)
        {
            if (id != pollPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(pollPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
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

        // POST: api/Polls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PollPostReadDTO>> PostPoll(PollPostCreateDTO pollPostDTO)
        {

            /* ICollection<PollQuestionCreateDTO> pqDTOs = pollDTO.PollQuestionsConnected;

             ICollection<PollQuestion> pqs = new List<PollQuestion>();
             foreach (PollQuestionCreateDTO pqDTO in pqDTOs)
             {
                 //Question question = _mapper.Map<Question>(pqDTO.Question);
                 //question = await _questionRepository.Create(question);


                 PollQuestion pq = _mapper.Map<PollQuestion>(pqDTO);


                 PollQuestion pqTemp = await _pqRepository.Create(pq);


                 pqs.Add(pqTemp);
             }

             */


            PollPost pp = _mapper.Map<PollPost>(pollPostDTO);

            Console.Write(pp);

            //Need to supply the poll ID to the PollQuestions so they get created?
            // 1. Map Poll
            // 2. Create PollQuestions
            // 3. Attach PollQuestions to Map
            // 4. Create Poll with PollQuestions
            //            p.PollQuestionsConnected = pqs;
            PollPost poll = await _ppRepository.Create(pp);


            return CreatedAtAction("GetPoll", new { id = poll.Id }, poll);
        }

        // DELETE: api/Polls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoll(long id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PollExists(long id)
        {
            return _context.Polls.Any(e => e.Id == id);
        }
    }
}
