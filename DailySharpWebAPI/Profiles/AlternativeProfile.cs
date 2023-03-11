
using AutoMapper;
using DailySharpWebAPI.Models;
using System;

public class AlternativeProfile : Profile
{

	public AlternativeProfile()
	{
		CreateMap<Alternative, AlternativeReadDTO>();
		CreateMap<AlternativeCreateDTO, Alternative>();
	}
}
