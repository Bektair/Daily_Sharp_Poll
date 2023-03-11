
using AutoMapper;
using DailySharpWebAPI.Models;
using System;

public class QuestionProfile : Profile
{

	public QuestionProfile()
	{
		CreateMap<Question, QuestionReadDTO>();
		CreateMap<QuestionCreateDTO, Question>();
	}
}
