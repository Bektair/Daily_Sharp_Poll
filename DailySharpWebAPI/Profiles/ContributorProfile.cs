
using AutoMapper;
using DailySharpWebAPI.Models;
using System;

public class ContributorProfile : Profile
{

	public ContributorProfile()
	{
		CreateMap<Contributor, ContributorReadDTO>();
		CreateMap<ContributorCreateDTO, Contributor>();

	}
}
