using AutoMapper;
using DailySharpWebAPI.DTOs;
using DailySharpWebAPI.Models;

namespace DailySharpWebAPI.Profiles;

public class PollPostProfile : Profile
{

    public PollPostProfile() 
    {
        CreateMap<PollPost, PollPostReadDTO>(); 
        CreateMap<PollPostCreateDTO, PollPost>();

    }

}
