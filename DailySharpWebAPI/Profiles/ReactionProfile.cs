
using AutoMapper;
using DailySharpWebAPI.DTOs;
using DailySharpWebAPI.Models;
using System;

public class ReactionProfile : Profile
{

	public ReactionProfile()
	{
		CreateMap<Reaction, ReactionReadDTO>();
		CreateMap<ReactionCreateDTO, Reaction>();
	}
}
