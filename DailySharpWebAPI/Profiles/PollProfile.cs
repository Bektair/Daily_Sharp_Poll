using AutoMapper;
using DailySharpWebAPI.DTOs;

namespace DailySharpWebAPI.Profiles;

public class PollProfile : Profile
{

    public PollProfile() 
    {
        CreateMap<Poll, PollReadDTO>(); 
        CreateMap<PollCreateDTO, Poll>();

    }

}
