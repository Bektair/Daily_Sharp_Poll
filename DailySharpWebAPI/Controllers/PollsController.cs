using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DailySharpWebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DailySharpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly DailyContext _context;
        private readonly IMapper _mapper;
        private readonly IPollRepository _pollRepository;
        private readonly IPollPostRepository _pqRepository;
        private readonly IQuestionRepository _questionRepository;

        public PollsController(DailyContext context, IMapper mapper, IPollRepository pollRepository, IPollPostRepository pqRepository, IQuestionRepository questionRepository)
        {
            _context = context;
            _mapper = mapper;
            _pollRepository = pollRepository;
            _pqRepository = pqRepository;
            _questionRepository = questionRepository;
        }

        // GET: api/Polls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollReadDTO>>> GetPolls()
        {

            IEnumerable<Poll> polls = await _pollRepository.ReadAll();

            PollReadDTO[] pollsDTO = _mapper.Map<IEnumerable<PollReadDTO>>(polls).ToArray();
            return pollsDTO;
        }

        // GET: api/Polls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollReadDTO>> GetPoll(long id)
        {
            Poll? poll = await _pollRepository.Read(id);

            if (poll == null)
            {
                return NotFound();
            }

            return _mapper.Map<PollReadDTO>(poll);
        }

        // PUT: api/Polls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(long id, Poll poll)
        {
            if (id != poll.Id)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

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
        public async Task<ActionResult<PollReadDTO>> PostPoll(PollCreateDTO pollDTO)
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


            Poll p = _mapper.Map<Poll>(pollDTO);

            Console.Write(p);

            //Need to supply the poll ID to the PollQuestions so they get created?
            // 1. Map Poll
            // 2. Create PollQuestions
            // 3. Attach PollQuestions to Map
            // 4. Create Poll with PollQuestions
//            p.PollQuestionsConnected = pqs;
            Poll poll = await _pollRepository.Create(p);
          

            return CreatedAtAction("GetPoll", new { id = poll.Id }, _mapper.Map<PollReadDTO>(poll));
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
